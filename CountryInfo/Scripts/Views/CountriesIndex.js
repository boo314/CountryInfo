$(document).ready(function () {
    var btnAddNewCountry = $("#addNewCountry");

    var modalDetails = $("#detailsModal");

    var modalAdd = $("#addModal");
    var btnAddCountry = $("#addCountry");
    var imgUploadAdd = $("#flagAdd");

    var modalEdit = $("#editModal");
    var btnEditCountry = $("#editCountry");

    var modalDelete = $("#deleteModal");
    var btnDeleteCountry = $("#DeleteCountry");


    btnAddNewCountry.click(function () {
        modalAdd.modal('show');
    });

    imgUploadAdd.change(function () {
        imagePreview(this, '#imgPreviewAdd');
    });


    btnAddCountry.click(function () {
        var form = $("#formAdd");
        var viewModel = getCountryViewModelFromForm(form);
        var data = JSON.stringify(viewModel);
        $.ajax({
            url: "Countries/Add",
            type: 'POST',
            data: "model=" + data,
            success: function (data) {
                modalAdd.modal('hide');
                console.log(data);
                getCountriesList();
            },
        });
    });

    btnAddNewCountry.click(function () {
        modalAdd.modal('show');
    });

    btnAddNewCountry.click(function () {
        modalAdd.modal('show');
    });

    btnAddNewCountry.click(function () {
        modalAdd.modal('show');
    });


    getCountriesList();
});

function getCountryViewModelFromForm(form) {
    var flagImage = $("#imgPreviewAdd");
    var result = {
        CountryName: form[0][0].value,
        CountryDescription: form[0][1].value,
        CountryPopulation: form[0][2].value,
        CapitalName: form[0][3].value,
        CapitalDescription: form[0][4].value,
        CapitalPopulation: form[0][5].value,
        FlagBase64: flagImage.attr("src")
    };

    return result;
}

function imagePreview(input, previewElement) {
    var imageHolder = $(previewElement);
    imageHolder.show();
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            imageHolder.attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }
}

function buildTable(entities) {
    var table = $("table");
    var newContent = "";
    for (var i = 0; i < entities.length; i++) {
        newContent += "<tr>" +
                            "<td>" + entities[i].CountryName + "</td>" +
                            "<td>" + entities[i].CapitalName + "</td>" +
                            "<td>" + entities[i].CountryPopulation + "</td>" +
                            "<td>" + entities[i].CapitalPopulation + "</td>" +
                            "<td><img src='" + entities[i].FlagBase64 + "' alt='" + entities[i].CountryName + "Flag'/></td>" +
                            "<td>" + "</td>" +
                        "</tr>";
    }
    table.find("tbody").html(newContent);
}

function getCountriesList() {
    $.ajax({
        url: "Countries/GetAllCountries",
        type: 'POST',
        success: function (data) {
            console.log(data);
            buildTable(data.Data);
        },
    });
}