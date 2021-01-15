console.log("connected")
alert("Wellcome to my stupid Game Quiz");

let userChoise = prompt("Please choose topic \n (type your topic or type the number of the topic) \n \n 1. GEOGRAPHY \n 2. SPORT \n 3. HISTORY");
userChoise = userChoise.toLowerCase();
let points = 0;
if (userChoise > 3 || userChoise <0){
    alert(`Please choose from 1 to 3`);
} 

// GEOGRAPHY
if (userChoise == 1 || userChoise === "geography"){
    alert("you choose GEOGRAPHY")

    // Question 1
    let geoAnswer1 = prompt("(1) What is Earth's largest continent? \n \n 1.Europe \n 2.Asia \n 3.Africa")
    geoAnswer1 = geoAnswer1.toLowerCase();
    geoAnswer1 = geoAnswer1.trim();
    geoAnswer1 = geoAnswer1.replace(" ","")

    if(geoAnswer1 == 2 || geoAnswer1 === "asia"){
        points = points + 10;
        alert(`Correct Answer \n \n You got ${points} points`);
        console.log(geoAnswer1);

    } else if (geoAnswer1 !== 2 || geoAnswer1 !== "asia"){
        points = points + 0;
        alert(`Incorrect Answer \n \n You got ${points} points`);
        console.log(geoAnswer1);
    }
    // Question 2
    let geoAnswer2 = prompt("(2) What is the oldest city in the world? \n \n 1.Damascus \n 2.Jerusalem \n 3.Athens")
    geoAnswer2 = geoAnswer2.toLowerCase();
    geoAnswer2 = geoAnswer2.trim();
    geoAnswer2 = geoAnswer2.replace(" ","")

    if(geoAnswer2 == 1 || geoAnswer2 === "damascus"){
        points = points + 10;
        alert(`Correct Answer \n \n You got ${points} points`);
        console.log(geoAnswer2);
    } else if (geoAnswer2 !== 1 || geoAnswer2 !== "damascus"){
        points = points + 0;
        alert(`Incorrect Answer \n \n You got ${points} points`);
        console.log(geoAnswer2);
    }
    // Question 3
    let geoAnswer3 = prompt("(2) What is the tallest mountain in the world? \n \n 1.Mount Kilimanjaro \n 2.Mont Blanc \n 3.Mount Everest")
    geoAnswer3 = geoAnswer3.toLowerCase();
    geoAnswer3 = geoAnswer3.trim();
    geoAnswer3 = geoAnswer3.replace(" ","")

    if(geoAnswer3 == 3 || geoAnswer3 === "mounteverest"){
        points = points + 10;
        alert(`Correct Answer \n \n You got ${points} points`);
        console.log(geoAnswer3);
    } else if (geoAnswer3 !== 3 || geoAnswer3 !== "mounteverest"){
        points = points + 0;
        alert(`Incorrect Answer \n \n You got ${points} points`);
        console.log(geoAnswer3);
    }
    alert(`You got ${points} out of 30 points`)    
} 

// SPORT
if (userChoise == 2 || userChoise === "sport"){
    alert("you choose SPORT")

     // Question 1
    let spoAnswer1 = prompt("(1) What is the name of the Barcelona football stadium ? \n \n 1.Santiago Bernabeu \n 2.Camp Nou \n 3.Allianz Arena")
    spoAnswer1 = spoAnswer1.toLowerCase();
    spoAnswer1 = spoAnswer1.trim();
    spoAnswer1 = spoAnswer1.replace(" ","")

    if(spoAnswer1 == 2 || spoAnswer1 === "campnou"){
        points = points + 10;
        alert("Correct Answer \n \n You got 10 points");
        console.log(spoAnswer1);
    } else if (spoAnswer1 !== 2 || spoAnswer1 !== "campnou"){
        points = points + 0;
        alert("Incorrect Answer \n \n You got 0 points");
        console.log(spoAnswer1);
    }

     // Question 2
    let spoAnswer2 = prompt("(1) In which country were the first Olympic Games held? \n \n 1.Greece \n 2.Italy \n 3.Germany")
    spoAnswer2 = spoAnswer2.toLowerCase();
    spoAnswer2 = spoAnswer2.trim();
    spoAnswer2 = spoAnswer2.replace(" ","")

    if(spoAnswer2 == 1 || spoAnswer2 === "greece"){
        points = points + 10;
        alert("Correct Answer \n \n You got 10 points");
        console.log(spoAnswer2);
    } else if (spoAnswer2 !== 1 || spoAnswer2 !== "greece"){
        points = points + 0;
        alert("Incorrect Answer \n \n You got 0 points");
        console.log(spoAnswer2);
    }

     // Question 3
    let spoAnswer3 = prompt("(1) Which representation won the 1998 FIFA World Cup? \n \n 1.Spain \n 2.Brasil \n 3.France")
    spoAnswer3 = spoAnswer3.toLowerCase();
    spoAnswer3 = spoAnswer3.trim();
    spoAnswer3 = spoAnswer3.replace(" ","")

    if(spoAnswer3 == 3 || spoAnswer3 === "france"){
        points = points + 10;
        alert("Correct Answer \n \n You got 10 points");
        console.log(spoAnswer3);
    } else if (spoAnswer3 !== 3 || spoAnswer3 !== "france"){
        points = points + 0;
        alert("Incorrect Answer \n \n You got 0 points");
        console.log(spoAnswer3);
    }
    alert(`You got ${points} out of 30 points`)
} 

// HISTORY
if (userChoise == 3 || userChoise === "history"){
    alert("you choose HISTORY")

    // Question 1
    let hisAnswer1 = prompt("(1) What year was WW2 started? \n \n 1.1939 \n 2.1945 \n 3.1919")
    hisAnswer1 = hisAnswer1.toLowerCase();
    hisAnswer1 = hisAnswer1.trim();
    hisAnswer1 = hisAnswer1.replace(" ","")

    if(hisAnswer1 == 1 || hisAnswer1 === "1939"){
        points = points + 10;
        alert("Correct Answer \n \n You got 10 points");
        console.log(hisAnswer1);
    } else if (hisAnswer1 !== 1 || hisAnswer1 !== "1939"){
        points = points + 0;
        alert("Incorrect Answer \n \n You got 0 points");
        console.log(hisAnswer1);
    }
    // Question 2
    let hisAnswer2 = prompt("(1) Who was the first president of the united states? \n \n 1.George Washington \n 2.Abraham Lincoln \n 3.Franklin Roosevelt ")
    hisAnswer2 = hisAnswer2.toLowerCase();
    hisAnswer2 = hisAnswer2.trim();
    hisAnswer2 = hisAnswer2.replace(" ","")

    if(hisAnswer2 == 1 || hisAnswer2 === "georgewashington"){
        points = points + 10;
        alert("Correct Answer \n \n You got 10 points");
        console.log(hisAnswer2);
    } else if (hisAnswer2 !== 1 || hisAnswer2 !== "georgewashington"){
        points = points + 0;
        alert("Incorrect Answer \n \n You got 0 points");
        console.log(hisAnswer2);
    }

    // Question 3
    let hisAnswer3 = prompt("(1) Where Was Adolf Hitler Born? \n \n 1.Germany \n 2.Austria \n 3.Poland ")
    hisAnswer3 = hisAnswer3.toLowerCase();
    hisAnswer3 = hisAnswer3.trim();
    hisAnswer3 = hisAnswer3.replace(" ","")

    if(hisAnswer3 == 2 || hisAnswer3 === "austria"){
        points = points + 10;
        alert("Correct Answer \n \n You got 10 points");
        console.log(hisAnswer3);
    } else if (hisAnswer3 !== 1 || hisAnswer3 !== "austria"){
        points = points + 0;
        alert("Incorrect Answer \n \n You got 0 points");
        console.log(hisAnswer3);
    }
    alert(`You got ${points} out of 30 points`)
}
