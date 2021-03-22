let uiService = {
    allBandsBtn: document.getElementById("showAllBands"),
    tableBody: document.getElementById("tableBody"),
    searchBox: document.getElementById("searchBox"),
    buttonSearch: document.getElementById("searchBtn"),
    activeBands: document.getElementById("activeBands"),
    dorpdownTags: document.getElementById("dropdown"),
    sortByName: document.getElementById("sortName"),
    sortByAlbum: document.getElementById("sortAlbums"),
    next: document.getElementById("next"),
    prev: document.getElementById("previous"),
    nextPrevButtons: document.getElementById("nextPreviousBtn"),
    flag: true,
    sort: function () {
        uiService.sortByName.addEventListener("click", function () {
            let sortedData = []
            getDataService.cashedData.forEach(element => sortedData.push(element))
            if (uiService.flag) {
                sortedData.sort(function (a, b) {
                    if (a.name < b.name) return -1;
                })
                uiService.flag = false
            } else {
                sortedData.sort(function (a, b) {
                    if (a.name > b.name) return -1;
                })
                uiService.flag = true
            }
            uiService.showTableBands(sortedData)
        })
        uiService.sortByAlbum.addEventListener("click", function () {
            let sortedData = []
            getDataService.cashedData.forEach(element => sortedData.push(element))
            if (uiService.flag) {
                sortedData.sort(function (a, b) {
                    if (a.albums.length < b.albums.length) return -1;
                })
                uiService.flag = false
            } else {
                sortedData.sort(function (a, b) {
                    if (a.albums.length > b.albums.length) return -1;
                })
                uiService.flag = true
            }
            uiService.showTableBands(sortedData)
        })
    },
    showTableBands: function (data, from = 0, to = 10) {
        uiService.nextPrevButtons.style.display = "block"
        uiService.tableBody.innerHTML = ""
        for (let i = from; i < to; i++) {
            uiService.tableBody.innerHTML += `
            <tr>
                <td class="tableColor">${i + 1}</td>
                <td class="tableColor" id="tableName">${data[i].name}</td>
                <td class="tableColor">${data[i].active ? "Yes" : "No"}</td>
                <td class="tableColor">${data[i].tags.join(', ')}</td>
                <td>${data[i].members.map(member => member.name).join('</br>')}</td>
                <td class="tableColor">${data[i].albums.length}</td>
            </tr>
            `
        }
    },
    showAllBands: function () {
        uiService.allBandsBtn.addEventListener("click", function () {
            uiService.searchBox.value = ""
            uiService.dorpdownTags.value = ""
            uiService.activeBands.checked = ""
            uiService.showTableBands(getDataService.cashedData)
        })
    },
    searchByName: function () {
        uiService.searchBox.addEventListener("keyup", function () {
            uiService.activeBands.checked = ""
            uiService.dorpdownTags.value = ""
            let nameList = getDataService.cashedData.filter((band) => {
                if ((band.name).toLowerCase().indexOf(uiService.searchBox.value.toLowerCase()) > -1) {
                    uiService.tableBody.innerHTML += `
                        <tr>
                            <td>1</td>
                            <td id="tableName">${band.name}</td>
                            <td>${band.active ? "Yes" : "No"}</td>
                            <td>${band.tags.join(', ')}</td>
                            <td>${band.members.map(member => member.name).join('</br>')}</td>
                            <td>${band.albums.length}</td>
                        </tr>
                        `
                    return band;
                }
            })
            uiService.showTableBands(nameList)
        })
    },
    showActiveBands: function () {
        uiService.activeBands.addEventListener("click", function () {
            uiService.searchBox.value = ""
            uiService.dorpdownTags.value = ""
            uiService.tableBody.innerHTML = ""
            if (uiService.activeBands.checked) {
                let activeBands = getDataService.cashedData.filter(band => {
                    if (band.active) return band
                })
                uiService.showTableBands(activeBands, 0, 18)
            } else uiService.showTableBands(getDataService.cashedData)
        })
    },
    tagsDropdown: function () {
        let bandsTags = []
        uiService.dorpdownTags.addEventListener("change", function () {
            uiService.searchBox.value = ""
            bandsTags = []
            uiService.tableBody.innerHTML = ""
            uiService.activeBands.checked = ""
            getDataService.cashedData.forEach(band => {
                band.tags.filter(tag => {
                    if (tag === uiService.dorpdownTags.value) bandsTags.push(band)
                })
            })
            uiService.showTableBands(bandsTags)
        })
    },
    tags: function () {
        let tagArr = []
        getDataService.cashedData.forEach(band => {
            for (let tag of band.tags) tagArr.push(tag)
        })
        tagArr = tagArr.filter((value, index) => tagArr.indexOf(value) === index);
        tagArr.forEach(tag => {
            uiService.dorpdownTags.innerHTML += `
            <option value="${tag}">${tag}</option>
            `
        })
    }
}
let getDataService = {
    cashedData: null,
    getData: async function () {
        let response = await fetch("https://raw.githubusercontent.com/sedc-codecademy/sedc6-frontend-exam/master/band-data.json")
        let bands = await response.json()
        getDataService.cashedData = bands
        uiService.showTableBands(getDataService.cashedData)
        uiService.tags()
        paging.setTotalPages(getDataService.cashedData)
    }
}
let paging = {
    fromPage: 0,
    toPage: 10,
    itemsPerPage: 10,
    currentPage: 1,
    totalPages: 0,
    pageListeners: function () {
        uiService.next.addEventListener("click", () => {
            if (paging.currentPage < paging.totalPages) {
                paging.fromPage += paging.itemsPerPage
                paging.toPage += paging.itemsPerPage
                paging.currentPage++
                document.getElementById("numPage").innerText = `${paging.currentPage}`
                paging.showHideButtons()
                uiService.showTableBands(getDataService.cashedData, paging.fromPage, paging.toPage)
            }
        })
        uiService.prev.addEventListener("click", () => {
            if (paging.currentPage > 1) {
                paging.fromPage -= paging.itemsPerPage
                paging.toPage -= paging.itemsPerPage
                paging.currentPage--
                paging.showHideButtons()
                document.getElementById("numPage").innerText = `${paging.currentPage}`
                uiService.showTableBands(getDataService.cashedData, paging.fromPage, paging.toPage)
            }
        })
    },
    setTotalPages: function (data) {
        paging.totalPages = Math.ceil(data.length / 10)
    },
    showHideButtons: function () {
        if (paging.currentPage <= 1) uiService.prev.style.display = "none"
        else uiService.prev.style.display = "inline"
        if (paging.currentPage >= paging.totalPages) uiService.next.style.display = "none"
        else uiService.next.style.display = "inline"
    }
}
getDataService.getData()
uiService.showAllBands()
uiService.searchByName()
uiService.showActiveBands()
uiService.tagsDropdown()
uiService.sort()
paging.pageListeners()
