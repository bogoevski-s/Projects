let button = document.getElementById("addTodo");
let remove = document.getElementById("remove")
let input = document.getElementById("userInput")
let list = document.getElementById("mainList")
let todo = [];

function addTodo() {
    if (input.value === "") {
        alert('empty todo');
    } else {
        list.innerHTML = ``
        let todoValue = input.value;
        todo.push(todoValue);
        for (let i = 0; i < todo.length; i++) {
            list.innerHTML += `<li>${todo[i]}</li>`
            // list.innerHTML +=`<li>${todo[i]} <i class="fas fa-trash-alt"></i></li>`
        }
        console.log(todo)
        input.value = "";

        // todo.push(input.value);
        // console.log(todo);
        // let listItems = document.createElement("LI")
        // list.appendChild(listItems);
        // listItems.innerText += input.value;
        // // list.innerHTML +=`<li>${input.value} <i class="fas fa-trash-alt"></i></li>`
        // input.value = "";
    }
}
function removeItem() {
    let todoValue = input.value;
    for (let i = 0; i < list.children.length; i++) {
        if (todoValue === list.children[i].innerText) {
            list.removeChild(list.children[i]);
            let index = todo.indexOf(todoValue);
            if (index > -1) {
                todo.splice(index, 1);
            }
        }
    }
    console.log(todo)
    input.value = "";
}

button.addEventListener('click', addTodo);
remove.addEventListener('click', removeItem);
