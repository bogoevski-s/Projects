let uiService = {
    searchInput: document.getElementById("search"),
    button: document.getElementById("searchBtn"),
    table: document.getElementById("table"),
    tableBody: document.getElementById("tableBody"),
    showAllButton: document.getElementById("showAll"),
    loader: document.getElementById("loader"),
    buttonDiv: document.getElementById("nextPreviousBtn"),

    search: function () {
        uiService.button.addEventListener("click", function (e) {
            e.preventDefault()
            if (uiService.searchInput.value === "") {
                uiService.showAlert('Please fill in Search field', 'danger');
                uiService.searchInput.value = ""
                return
            }
            uiService.buttonDiv.style.display = "none"
            let nameSearch = countriesApiService.cashedData.filter((countries) => {
                if (countries.name.toLowerCase().indexOf(uiService.searchInput.value.toLowerCase()) > -1) {
                    tableBody.innerHTML += `
                    <tr>
                        <td><img src="${countries.flag}"></td>
                        <td>${countries.name}</td>
                        <td>${countries.population}</td>
                        <td>${countries.capital}</td>
                        <td>${countries.area} Km2</td>
                        <td>${countries.languages[0].name}</td>
                        <td>${countries.currencies[0].name} - ${countries.currencies[0].symbol}</td>
                    </tr>
                    `
                    return countries
                }
            })
            uiService.showAll(nameSearch)
            uiService.searchInput.value = ""
        })
        uiService.showAllButton.addEventListener("click", () => {
            uiService.searchInput.value = ""
            uiService.buttonDiv.style.display = "block"
            pagingService.from = 0
            pagingService.to = 10
            pagingService.page = 1
            pagingService.totalPages = 0
            pagingService.currentPageContainer.innerHTML = `<p>currnet page - ${pagingService.page}</p>`;
            countriesApiService.getAllData()
            pagingService.previousPage.style.display = "none"
            pagingService.nextPage.style.display = "inline"
            pagingService.currentPageContainer.style.display = "inline"
        })
    },
    showAlert: function (message, className) {
        uiService.loader(false)
        const div = document.getElementById("alert")
        div.style.display = "block"
        div.className = `alert alert-${className}`
        div.innerHTML = `<h3>${message}</h3>`
        setTimeout(() => {
            div.style.display = "none"
        }, 2000)
    },
    showAll: function (data, from = 0, to = 10) {
        table.style.display = "inline-table"
        tableBody.innerHTML = ""
        for (let i = from; i < to; i++) {
            tableBody.innerHTML += `
            <tr>
                <td><img src="${data[i].flag}"></td>
                <td>${data[i].name}</td>
                <td>${data[i].population}</td>
                <td>${data[i].capital}</td>
                <td>${data[i].area} Km2</td>
                <td>${data[i].languages[0].name}</td>
                <td>${data[i].currencies[0].name} - ${data[i].currencies[0].symbol}</td>
            </tr>
            `
        }

    },
    loader: function (toggle) {
        if (toggle) loader.style.display = "block";
        else loader.style.display = "none"
    }
}
let pagingService = {
    previousPage: document.getElementById("previous"),
    nextPage: document.getElementById("next"),
    pagingButtonsContainer: document.getElementById("pagingButtons"),
    currentPageContainer: document.getElementById("currnetPage"),
    from: 0,
    to: 10,
    page: 1,
    totalPages: 0,
    pagingListeneres: function () {
        this.previousPage.addEventListener("click", function () {
            uiService.loader(true)
            if (pagingService.page > 1) {
                pagingService.from -= 10
                pagingService.to -= 10
                pagingService.page--
            }
            pagingService.adaptPageButtons()
            countriesApiService.getAllData()
        })
        this.nextPage.addEventListener("click", function () {
            uiService.loader(true)
            if (pagingService.page < pagingService.totalPages) {
                pagingService.from += 10
                pagingService.to += 10
                pagingService.page++
            }
            pagingService.adaptPageButtons()
            countriesApiService.getAllData()
        })
    },
    adaptPageButtons: function () {
        pagingService.page <= 1
            ? pagingService.previousPage.style.display = "none"
            : pagingService.previousPage.style.display = "inline"

        pagingService.page >= pagingService.totalPages
            ? pagingService.nextPage.style.display = "none"
            : pagingService.nextPage.style.display = "inline"

        pagingService.currentPageContainer.innerHTML = `<p>currnet page - ${pagingService.page}</p>`;
    },
    setTotalPages: function (list) {
        pagingService.totalPages = Math.ceil(list.length) / 10
    }
}
let sortSearch = {
    directionAB: true,
    sortByName: function () {
        document.getElementById("nameSort").addEventListener("click", () => {
            if (sortSearch.directionAB === true) {
                countriesApiService.cashedData.sort(function (a, b) {
                    if (a.name < b.name) return -1;
                })
                sortSearch.directionAB = false;
            }
            else if (sortSearch.directionAB === false) {
                countriesApiService.cashedData.sort(function (a, b) {
                    sortSearch.directionAB = true;
                    if (a.name > b.name) return -1;
                })
            }
            uiService.showAll(countriesApiService.cashedData)
        })
    },
    sortByPopulation: function () {
        document.getElementById("populationSort").addEventListener("click", () => {
            if (sortSearch.directionAB === true) {
                countriesApiService.cashedData.sort(function (a, b) {
                    if (a.population < b.population) return -1;
                })
                sortSearch.directionAB = false;
            }
            else if (sortSearch.directionAB === false) {
                countriesApiService.cashedData.sort(function (a, b) {
                    sortSearch.directionAB = true;
                    if (a.population > b.population) return -1;
                })
            }
            uiService.showAll(countriesApiService.cashedData)
        })
    },
    sorthByArea: function () {
        document.getElementById("areaSort").addEventListener("click", () => {
            if (sortSearch.directionAB === true) {
                countriesApiService.cashedData.sort(function (a, b) {
                    if (a.area < b.area) return -1;
                })
                sortSearch.directionAB = false;
            }
            else if (sortSearch.directionAB === false) {
                countriesApiService.cashedData.sort(function (a, b) {
                    sortSearch.directionAB = true;
                    if (a.area > b.area) return -1;
                })
            }
            uiService.showAll(countriesApiService.cashedData)
        })
    }
}
let countriesApiService = {
    cashedData: null,
    getAllData: async function () {
        try {

            let res = await fetch("https://restcountries.eu/rest/v2/all")
            let dataAll = await res.json()
            countriesApiService.cashedData = dataAll
            uiService.showAll(countriesApiService.cashedData, pagingService.from, pagingService.to)
            pagingService.setTotalPages(countriesApiService.cashedData)
        }
        catch (error) {
            uiService.showAlert(`Sorry something went wrong`)
            console.log(error)
        }
        finally {
            uiService.loader(false)
        }
    }
}
countriesApiService.getAllData()
uiService.search()
pagingService.pagingListeneres()
sortSearch.sortByName()
sortSearch.sortByPopulation()
sortSearch.sorthByArea()