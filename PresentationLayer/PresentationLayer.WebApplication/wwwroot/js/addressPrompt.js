var
    $region = $("#region"),
    $city = $("#city"),
    $street = $("#street"),
    $house = $("#house"),
    $addressFilter = $("#addressFilter");

var
    $regionList = $("#regionList"),
    $cityList = $("#cityList"),
    $streetList = $("#streetList"),
    $houseList = $("#houseList"),
    $addressFilterList = $("#addressFilterList");

function getAddressPrompt() {
    $addressFilterList.empty();
    getPromptDataAjax($addressFilter, "/Prompt/GetRegion", $addressFilterList);
    getPromptDataAjax($addressFilter, "/Prompt/GetCity", $addressFilterList);
}

function getRegionsListAjax() {
    $regionList.empty();
    getPromptDataAjax($region, "/Prompt/GetRegion", $regionList);
}

function getCitiesListAjax() {
    $cityList.empty();
    getPromptDataAjax($city, "/Prompt/GetCity", $cityList, $region.attr("geo_id"));
}

function getStreetsListAjax() {
    $streetList.empty();
    getPromptDataAjax($street, "/Prompt/GetStreet", $streetList, $city.attr("geo_id"));
}

function getHouseListAjax() {
    $houseList.empty();
    getPromptDataAjax($house, "/Prompt/GetHouse", $houseList, $street.attr("geo_id"));
}


function setRegion() {
    setGeoId($region, $regionList);
}

function setCity() {
    setGeoId($city, $cityList);
}

function setStreet() {
    setGeoId($street, $streetList);
}

function setHouse() {
    setGeoId($house, $houseList);
}


/**
 * Функция предназначена для получения предполагаемых вариантов адреса по заданному предположению
 * @param guess Строка с предполагаемым адресом (или его частью)
 * @param ApiSource Адрес, куда будет производиться запрос
 * @param destination JQuery объект, куда будут помещаться данные
 * @param constraint Условие ограничения поиска
 */
function getPromptDataAjax(guess, ApiSource, destination, constraint) {
    //Формирование данных для отправки на сервер
    var sendData = constraint ? {
        Query: guess.val(),
        Constraint: constraint
    } :
        {
            Query: guess.val(),
        };
    if (guess.val()) {
        $.post({
            url: document.location.origin + ApiSource,
            data: sendData,
            dataType: "json",
            success: function (data) {
                $.each(data, function (_, v) {
                    $("<option/>", {
                        text: v.address,
                        geo_id: v.addressId
                    })
                        .appendTo(destination);
                })
            }
        });
    }
}

/**
 * Функция предназначена для сохранения Id найденного адреса.
 * @param place Введённый адрес
 * @param placeList Список с найденными адресами
 */
function setGeoId(place, placeList) {
    var selectedRegion = placeList
        .children("option")
        .filter(() => $(this).text() == place.text());
    place.attr({
        geo_id: selectedRegion.attr("geo_id")
    });
}