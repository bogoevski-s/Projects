// Start game div selectors
startDiv = document.getElementById("start-container");
playButton = document.getElementById("playBtn");
// Category game div selectors
categoryDisplay = document.getElementById("category-container");
// Difficulty level
difficultyDisplay = document.getElementById("difficulty-container")
// Game div selectors
gameDiv = document.getElementById("game-container");
questionDisplay = document.getElementById("question");
// Buttons next/quit div selectors
nextBtn = document.getElementById("nexBtn");
quitBtn = document.getElementById("quitBtn");
allButtons = document.getElementsByClassName("buttons");
score = document.getElementById("score");
answerDiv = document.getElementById("answers");

// Start Game
playButton.addEventListener("click", () => {
    category();
    startDiv.style.display = "none";
    gameDiv.style.display = "none";
})
// Category
let userCategory = "";
let category = function () {
    categoryDisplay.style.display = "flex"
}
document.querySelectorAll(".btn").forEach(allCategory => {
    allCategory.addEventListener("click", () => {
        if (allCategory.value === "&category=21") {
            userCategory = "&category=21";
            categoryDisplay.style.display = "none"
            difficultyLevel()
        } else if (allCategory.value === "&category=22") {
            userCategory = "&category=22";
            categoryDisplay.style.display = "none"
            difficultyLevel()
        } else if (allCategory.value === "&category=23") {
            userCategory = "&category=23";
            categoryDisplay.style.display = "none"
            difficultyLevel()
        } else if (allCategory.value === "&category=18") {
            userCategory = "&category=18";
            categoryDisplay.style.display = "none"
            difficultyLevel()
        }
    })
})

// Difficulty level
let userDifficulty = ""
let difficultyLevel = function () {
    categoryDisplay.style.display = "none";
    difficultyDisplay.style.display = "flex";
}
document.querySelectorAll(".btn").forEach(difficulty => {
    difficulty.addEventListener("click", () => {
        if (difficulty.value === "&difficulty=easy") {
            userDifficulty = "&difficulty=easy";
            difficultyDisplay.style.display = "none"
            gameDiv.style.display = "flex";
            getDataAsync(userCategory, userDifficulty)
        } else if (difficulty.value === "&difficulty=medium") {
            userDifficulty = "&difficulty=medium";
            difficultyDisplay.style.display = "none"
            gameDiv.style.display = "flex";
            getDataAsync(userCategory, userDifficulty)
        } else if (difficulty.value === "&difficulty=hard") {
            userDifficulty = "&difficulty=hard";
            difficultyDisplay.style.display = "none"
            gameDiv.style.display = "flex";
            getDataAsync(userCategory, userDifficulty)
        }
    })
})

// Getting data
async function getDataAsync(category, difficulty) {
    let response = await fetch(`https://opentdb.com/api.php?amount=1${category}${difficulty}&type=multiple`)
    let question = await response.json()
    console.log(question)
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
    getDataAsync(userCategory, userDifficulty)
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
    categoryDisplay.style.display = "none"
    difficultyDisplay.style.display = "none";
    questionDisplay.innerHTML = ``
    answerDiv.innerHTML = ``
    score.innerHTML = ``
    nextBtn.style.display = "none"
    quitBtn.style.display = "none"
    points = 0
    userCategory = "";
    userDifficulty = "";
}
quitBtn.addEventListener("click", quit)

