playButton = document.getElementById("playBtn");
startDiv = document.getElementById("start-container")
gameDiv = document.getElementById("game-container")
scoreDisplay = document.getElementById("score");
questionDisplay = document.getElementById("question")

nextBtn = document.getElementById("nexBtn")
quitBtn = document.getElementById("quitBtn")
allButtons = document.getElementsByClassName("buttons")
score = document.getElementById("score")
answerDiv = document.getElementById("answers")


// Start Game
playButton.addEventListener("click", () => {
    getDataAsync()
    startDiv.style.display = "none";
    gameDiv.style.display = "flex";

})
// Getting data
async function getDataAsync() {
    let response = await fetch("https://opentdb.com/api.php?amount=1&type=multiple")
    let question = await response.json()
    displayQuestion(question)
}

let allAnswers = [];
let correctAnswer = "";
let points = 0

// Display questions
let displayQuestion = function (data) {
    answerDiv.innerHTML = ``
    score.innerHTML = `<h3>Points ${points}</h3>`
    allAnswers = data.results[0].incorrect_answers
    allAnswers.push(data.results[0].correct_answer)
    correctAnswer = data.results[0].correct_answer
    allAnswers.sort(() => Math.random() - 0.5)
    questionDisplay.innerHTML = `<h1>${data.results[0].question}</h1>`
    for (const answer of allAnswers) {
        answerDiv.innerHTML += `<button class="buttons">${answer}</button>`
    }
    answers()
}

// Answers listeners
let answers = function () {
    let clickCount = 0;
    document.querySelectorAll('.buttons').forEach(item => {
        item.addEventListener('click', () => {
            if (clickCount === 0) {
                if (item.textContent === correctAnswer) {
                    item.style.background = "linear-gradient(90deg, rgba(57, 255, 7, 0.715) 0%, rgba(57, 255, 7, 0.715) 100%)"
                    nextBtn.style.display = "block"
                    quitBtn.style.display = "block"
                    points += 10;
                    score.innerHTML = `<h3>Points ${points}</h3>`
                } else {
                    item.style.background = "linear-gradient(90deg, rgba(255, 0, 0, 0.715) 0%, rgba(255, 0, 0, 0.715) 100%)"
                    nextBtn.style.display = "block"
                    quitBtn.style.display = "block"
                    points += 0;
                    score.innerHTML = `<h3>Points ${points}</h3>`
                    correctAnswerIfWrong()
                }
            } else {
                return
            }
            clickCount++;
        })
    })
}
// Show correct answer if user choose worng
let correctAnswerIfWrong = function () {
    document.querySelectorAll('.buttons').forEach(item => {
        if (item.textContent === correctAnswer) {
            item.style.background = "linear-gradient(90deg, rgba(57, 255, 7, 0.715) 0%, rgba(57, 255, 7, 0.715) 100%)"
        }
    })
}

// Next question BTN
let nextQuestion = function () {
    getDataAsync()
    document.querySelectorAll('.buttons').forEach(item => {
        item.style.backgroundColor = "transparent"
    })
    nextBtn.style.display = "none"
    quitBtn.style.display = "none"
    allAnswers = [];
    correctAnswer = ""
}
nextBtn.addEventListener("click", nextQuestion)

// Quit button
let quit = function () {
    startDiv.style.display = "flex";
    gameDiv.style.display = "none";
    questionDisplay.innerHTML = ``
    answerDiv.innerHTML = ``
    score.innerHTML = ``
    nextBtn.style.display = "none"
    quitBtn.style.display = "none"
    points = 0
}
quitBtn.addEventListener("click", quit)

try {
    getDataAsync()
}
catch (error) {
    console.warn(error)
}