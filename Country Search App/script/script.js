let uiService = {
    searchInput: document.getElementById("search"),
    button: document.getElementById("searchBtn"),
    table: document.getElementById("table"),
    tableBody: document.getElementById("tableBody"),
    showAllButton: document.getElementById("showAll"),

    search: function () {
        uiService.button.addEventListener("click", (e) => {
            e.preventDefault()
            let country = uiService.searchInput.value
            if (country === "") {
                uiService.showAlert('Please fill in Search field', 'danger')
            } else {
                countriesApiService.getData(country)
            }
            uiService.searchInput.value = ""
        })
        uiService.showAllButton.addEventListener("click", () => {
            pagingService.from = 0
            pagingService.to = 10
            pagingService.page = 1
            pagingService.totalPages = 0
            pagingService.currentPageContainer.innerHTML = `<p>currnet page - ${pagingService.page}</p>`;
            countriesApiService.getAllData()
            pagingService.nextPage.style.display = "inline"
            pagingService.currentPageContainer.style.display = "inline"
        })
    },
    showCountries: function (data) {
        pagingService.nextPage.style.display = "none"
        pagingService.currentPageContainer.style.display = "none"
        pagingService.previousPage.style.display = "none"

        table.style.display = "inline-table"
        tableBody.innerHTML = `
        <tr>
            <td><img src="${data.flag}"></td>
            <td>${data.name}</td>
            <td>${data.population}</td>
            <td>${data.capital}</td>
            <td>${data.area} Km2</td>
            <td>${data.languages[0].name}</td>
            <td>${data.currencies[0].name} - ${data.currencies[0].symbol}</td>
        </tr>
        `
    },
    showAlert: function (message, className) {
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
            if (pagingService.page > 1) {
                pagingService.from -= 10
                pagingService.to -= 10
                pagingService.page--
            }
            pagingService.adaptPageButtons()
            countriesApiService.getAllData()
        })
        this.nextPage.addEventListener("click", function () {
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
    },
    createPagingButtons: function () {
        pagingService.pagingButtonsContainer.innerHTML = ""
        for (let i = 0; i < pagingService.totalPages; i++) {
            pagingService.pagingButtonsContainer.innerHTML = `
                <button class="btn btn-outline-success buttonsNextPrevious" id="page${i + 1}">${i + 1}</button>
            `
        }
        for (let i = 0; i < pagingService.totalPages; i++) {
            document.getElementById(`page${i + 1}`).addEventListener("click", function () {
                pagingService.from = i * 10;
                pagingService.to = (i + 1) * 10;
                pagingService.page = i + 1
                pagingService.adaptPageButtons()
                countriesApiService.getAllData()
            })
        }
    }
}

let filterSearch = {
    directionAB: true,
    buttonsListeners: function () {
        document.querySelectorAll(".filter").forEach(item => {
            item.addEventListener("click", () => {
                // console.log(`${item.textContent} is clicked`)
                // console.log(countriesApiService.cashedData)
                if (filterSearch.directionAB === true) {
                    countriesApiService.cashedData.sort(function (a, b) {
                        if (a.name < b.name) return -1;
                    })
                    filterSearch.directionAB = false;
                }
                else if (filterSearch.directionAB === false) {
                    countriesApiService.cashedData.sort(function (a, b) {
                        filterSearch.directionAB = true;
                        if (a.name > b.name) return -1;
                    })
                }
                uiService.showAll(countriesApiService.cashedData, pagingService.from, pagingService.to)
            })
        })
    }
}

let countriesApiService = {
    cashedData: null,
    getData: async function (name) {
        try {
            let response = await fetch(`https://restcountries.eu/rest/v2/name/${name}?fullText=true`)
            let data = await response.json()
            countriesApiService.cashedData = data[0];
            uiService.showCountries(countriesApiService.cashedData)
        }
        catch (error) {
            uiService.showAlert(`Sorry we found nothing about "${name}"`, 'warning')
            console.log("somting went worng")
            console.log(error)
        }
    },
    getAllData: async function () {
        let res = await fetch("https://restcountries.eu/rest/v2/all")
        let dataAll = await res.json()
        countriesApiService.cashedData = dataAll

        uiService.showAll(countriesApiService.cashedData, pagingService.from, pagingService.to)
        pagingService.setTotalPages(countriesApiService.cashedData)
    },
}

uiService.search()
pagingService.pagingListeneres()
filterSearch.buttonsListeners()



