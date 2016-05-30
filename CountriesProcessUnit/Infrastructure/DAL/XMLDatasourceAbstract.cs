using CountriesProcessUnit.Infrastructure.Exceptions;
using CountriesProcessUnit.Models;
using CountriesProcessUnit.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace CountriesProcessUnit.Infrastructure.DAL
{
    public abstract class XMLDatasourceAbstract<TEntity>
    {
        protected string url;
        protected XmlSerializer serializer;
        protected IEnumerable<TEntity> memory;

        public XMLDatasourceAbstract(string dataFileLocation)
        {
            url = dataFileLocation;
            serializer = new XmlSerializer(typeof(XmlDatasourceModel<TEntity>));
            //memory = LoadFile();
            memory = new List<TEntity>();
        }

        public abstract bool Add(CountryViewModel viewModel);

        public abstract bool AddRange(IEnumerable<CountryViewModel> viewModel);

        public abstract IEnumerable<CountryViewModel> GetAll();

        public abstract CountryViewModel Get(Func<TEntity, bool> condition);

        #region Private methods

        protected IEnumerable<TEntity> LoadFile()
        {
            var result = new List<TEntity>();
            try
            {
                using (var fileStream = new FileStream(url, FileMode.OpenOrCreate))
                {
                    if (fileStream.Length == 0)
                    {
                        InitializeDocument(fileStream);
                    }
                    else
                    {
                        var xml = (XmlDatasourceModel<TEntity>)serializer.Deserialize(fileStream);
                        result.AddRange(xml.DataList);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new CantLoadEntityException("Cannot load entities from Xml file", ex);
            }
            return result;
        }

        protected bool SaveFile()
        {
            var result = false;
            var xmlModel = new XmlDatasourceModel<TEntity>
            {
                DataList = memory.ToArray()
            };
            try
            {
                using (var fileStream = new FileStream(url, FileMode.OpenOrCreate))
                {
                    fileStream.Write(new byte[] { }, 0, 0);
                    serializer.Serialize(fileStream, xmlModel);
                }
                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new CantSaveEntityException("Cannot save memory to Xml file.", ex);
            }
            return result;
        }

        protected bool InitializeDocument(Stream stream)
        {
            var result = false;
            try
            {
                var xmlDatasourceModel = new XmlDatasourceModel<TEntity>
                {
                    DataList = new TEntity[0]
                };
                serializer.Serialize(stream, xmlDatasourceModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            return result;
        }

        #endregion Private methods
    }
}