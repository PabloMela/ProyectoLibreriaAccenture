let main = document.querySelector("main")

let boton = document.querySelector("button")

let menu = document.querySelector("nav")

boton.addEventListener("click", () => {
    if (menu.className == "cerrado")
        menu.className = "abierto"
    else
        menu.className = "cerrado"
})

let opciones = document.querySelectorAll("a")

opciones.forEach(opcion => {
    opcion.addEventListener("click", e => {
        e.preventDefault()
        ajax(e.target.href)
    })
});

function ajax(url) {
    let xhr = new XMLHttpRequest
    xhr.open("GET", url)
    xhr.addEventListener("readystatechange", () => {
        if (xhr.readyState == 4 && xhr.status == 200) {
            menu.className = "cerrado"
            main.innerHTML = xhr.response
        }
    })
    xhr.send()
}