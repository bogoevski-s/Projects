let balance = 1000;
let player = [];

let dealer = [];
let bet = 0;

function begin(){
    alert(`B L A C K J A C K  \n\nYOUR BALANCE  -  ${balance} $`);
    bet = parseInt(prompt(`BALANCE  -  ${balance}$ \n\nYour bet please`));
}

function playerCard1(){
    player = [Math.floor(Math.random() * 10 + 1), Math.floor(Math.random() * 10 + 1)];
    return (player);
}
function dealerCard1(){
    dealer = [Math.floor(Math.random() * 10 + 1), Math.floor(Math.random() * 10 + 1)];
    return (dealer);
}

function stand(){
    dealerHit();
    
    if (player.reduce((a, b) => a + b, 0) === 21) {
        balance = balance + bet * 2.5;
        alert(`B L A C K J A C K \n\nDEALER ---- ${dealer.reduce((a, b) => a + b, 0)}\nYOU ------- ${player.reduce((a, b) => a + b, 0)}\n\nY O U  W I N   ${bet * 2.5}\nNew balance ${balance}`);
    } else if (player.reduce((a, b) => a + b, 0) > dealer.reduce((a, b) => a + b, 0)) {
        balance = balance + bet * 2;
        alert(`WIN - WIN - WIN - WIN - WIN\n\nDEALER ----${dealer}          TOTAL --- ${dealer.reduce((a, b) => a + b, 0)}\nYOU --------${player}          TOTAL --- ${player.reduce((a, b) => a + b, 0)}\n\nY O U   W I N    --   ${bet * 2}\nNew balance ${balance}`);
    } else if (player.reduce((a, b) => a + b, 0) < dealer.reduce((a, b) => a + b, 0)) {
        balance = balance - bet;
        alert(`- BUSTED - \n\nDEALER WINS ---- ${dealer.reduce((a, b) => a + b, 0)}\nYOU ------- ${player.reduce((a, b) => a + b, 0)}\n\n\nYOU LOST ${bet * 2}\nNew balance ${balance}`);
    } else if (player.reduce((a, b) => a + b, 0) == dealer.reduce((a, b) => a + b, 0)) {
        alert(`- PUSH - \n\nDEALER ---- ${dealer.reduce((a, b) => a + b, 0)}\nYOU -------- ${player.reduce((a, b) => a + b, 0)}\n\n\n PUSH  ${bet * 2}\nNew balance ${balance}`);
        dealerCard1();
        playerCard1();
        blackJack();
    }

    begin();
    dealerCard1();
    playerCard1();
    blackJack();
}

function hit(){
    dealerHit();
    player.push(Math.floor(Math.random() * 10 + 1));

    if (player.reduce((a, b) => a + b, 0) > 21) {
        balance = balance - bet * 2;
        alert(`- BUSTED - \n\nDEALER WINS ---- ${dealer.reduce((a, b) => a + b, 0)}\nYOU --------------- ${player.reduce((a, b) => a + b, 0)}\n\n\nYOU LOST ${bet * 2}\nNew balance ${balance}`);
        begin();
        dealerCard1();
        playerCard1();
        blackJack();
    } else {
        blackJack();
    }
}
function dealerHit(){
    if (dealer.reduce((a, b) => a + b, 0) <= 10) {
        dealer.push(Math.floor(Math.random() * 10 + 1));
    } else if (dealer.reduce((a, b) => a + b, 0) <= 12) {
        dealer.push(Math.floor(Math.random() * 10 + 1));
    }

    return (dealer);
}

function doubleX2(){
    dealerHit();
    player.push(Math.floor(Math.random() * 10 + 1));

    if (player.reduce((a, b) => a + b, 0) === 21) {
        balance = balance + (bet + bet) * 2.5;
        alert(`B L A C K J A C K \n\nDEALER ---- ${dealer.reduce((a, b) => a + b, 0)}\nYOU ------- ${player.reduce((a, b) => a + b, 0)}\n\nY O U  W I N   ${bet * 2.5}\nNew balance ${balance}`);
    } else if (player.reduce((a, b) => a + b, 0) > dealer.reduce((a, b) => a + b, 0)) {
        balance = balance + (bet + bet) * 2;
        alert(`WIN - WIN - WIN - WIN - WIN\n\nDEALER ----${dealer}          TOTAL --- ${dealer.reduce((a, b) => a + b, 0)}\nYOU -------${player}          TOTAL --- ${player.reduce((a, b) => a + b, 0)}\n\nY O U   W I N    --   ${bet * 2}\nNew balance ${balance}`);
    } else if (player.reduce((a, b) => a + b, 0) < dealer.reduce((a, b) => a + b, 0)) {
        balance = balance - (bet + bet) * 2;
        alert(`- BUSTED - \n\nDEALER WINS ---- ${dealer.reduce((a, b) => a + b, 0)}\nYOU ------- ${player.reduce((a, b) => a + b, 0)}\n\n\nYOU LOST ${bet * 2}\nNew balance ${balance}`);
    } else if (player.reduce((a, b) => a + b, 0) == dealer.reduce((a, b) => a + b, 0)) {
        alert(`- PUSH - \n\nDEALER ---- ${dealer.reduce((a, b) => a + b, 0)}\nYOU ------- ${player.reduce((a, b) => a + b, 0)}\n\n\n PUSH  ${bet * 2}\nNew balance ${balance}`);
        dealerCard1();
        playerCard1();
        blackJack();
    }

    begin();
    dealerCard1();
    playerCard1();
    blackJack();
}

function blackJack(){
    let select = parseInt(prompt(`DEALER        ??     ${dealer[1]} -  ${dealer[2]} -  ${dealer[3]} \n \nPLAYER       ${player}    TOTAL  -- ${player.reduce((a, b) => a + b, 0)} \n\n\n 1. Stand \n 2. Hit \n 3. Double X 2`));
    switch (select) {
        case 1:
            stand();
            break;
        case 2:
            hit();
            break;
        case 3:
            doubleX2();
            break;
    }
}

begin();
dealerCard1();
playerCard1();
blackJack();