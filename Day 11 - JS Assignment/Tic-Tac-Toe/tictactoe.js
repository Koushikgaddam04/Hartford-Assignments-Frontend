

let btnreset = document.getElementById("reset");
btnreset.style.display = "none";
let table = document.getElementById("tictactoe");
let arr = [['', '', ''], ['', '', ''], ['', '', '']];
let count=0;
f = true;
let playerturn = document.querySelector(".card p span");
playerturn.innerText = 'X';

function display(row, col) {
    console.log(row, col);
    let ele;
    if (arr[row][col] != '') {
        alert("Cell already occupied");
        return;
    }
    if(f){
        ele='X';
        f=false;
        playerturn.innerText = 'O';
    }else{
        ele='O';
        f=true;
        playerturn.innerText = 'X';
    }
    change(row, col, ele);
    count++;
    arr[row][col] = ele;
    if (checkwin()) {
        console.log("Game finished");
        btnreset.style.display = "block";
    }
    if(count==9){
        alert("It's a draw");
        btnreset.style.display = "block";
    }
}


function change(row, col, ele){
    if (row == 0 && col == 0) {
        document.getElementById("0").innerHTML = ele;
    }
    else if (row == 0 && col == 1) {
        document.getElementById("1").innerHTML = ele;
    }
    else if (row == 0 && col == 2) {
        document.getElementById("2").innerHTML = ele;
    }
    else if (row == 1 && col == 0) {
        document.getElementById("3").innerHTML = ele;
    }
    else if (row == 1 && col == 1) {
        document.getElementById("4").innerHTML = ele;
    }
    else if (row == 1 && col == 2) {
        document.getElementById("5").innerHTML = ele;
    }
    else if (row == 2 && col == 0) {
        document.getElementById("6").innerHTML = ele;
    }
    else if (row == 2 && col == 1) {
        document.getElementById("7").innerHTML = ele;
    }
    else if (row == 2 && col == 2) {
        document.getElementById("8").innerHTML = ele;
    }

}

function checkwin(){
    for(let i=0;i<3;i++){
        if(arr[i][0]==arr[i][1] && arr[i][1]==arr[i][2] && arr[i][0]!=''){
            alert(arr[i][0]+" wins");
            return true;
        }
        if(arr[0][i]==arr[1][i] && arr[1][i]==arr[2][i] &&  arr[0][i]!=''){
            alert(arr[0][i]+" wins");
            return true;
        }
    }
    if(arr[0][0]==arr[1][1] && arr[1][1]==arr[2][2] && arr[0][0]!=''){
        alert(arr[0][0]+" wins");
        return true;
    }
    if(arr[0][2]==arr[1][1] && arr[1][1]==arr[2][0] && arr[0][2]!=''){
        alert(arr[0][2]+" wins");
        return true;
    }
    return false;
}

function reset(){
    for(let i=0;i<3;i++){
        for(let j=0;j<3;j++){
            arr[i][j]='';
        }
    }
    count = 0;
    for(let i=0;i<9;i++){
        document.getElementById(i.toString()).innerHTML = '';
    }
    btnreset.style.display = "none";
    f=true;
}