var audio = document.getElementById("music");  //用ID取得文件上的某一個元素music
var btnPlay = document.getElementById("btnPlay");
var volValue = document.getElementById("volValue");
var info = document.getElementById("info");
var song = document.getElementById("song");
var volinfo = document.getElementById("volinfo")
var progress = document.getElementById("progress");
var book = document.getElementById("book");
//若要抓info內的子節點來執行指令，要使用info.children[0]，[0]為第一個項目。
/*//console.log(audio.children[0].title);*/




song.addEventListener('change', function () {  //在這段裡function()內不能直接寫函數，所以再用{}寫出需要的函數
    changeMusic(song.selectedIndex);
});

var option;
var tBook = book.children[1];

function updateMusic() {

    //先移除目前下拉選單中所有歌曲，須從最後一首開始刪，否則刪除第一首後，第二首的[j]會成為第一首
    for (var j = song.children.length - 1; j >= 0; j--) {
        song.removeChild(song.children[j]);
    }

    //再抓音樂庫中的歌曲到下拉選單
    for (var i = 0; i < tBook.children.length; i++) {
        option = document.createElement("option");
        option.innerText = tBook.children[i].innerText;
        option.value = tBook.children[i].title;
        song.appendChild(option);
    }
    changeMusic(0);
}



function allowDrop(ev) {
    ev.preventDefault(); //preventDefault：停止物件預設行為
}

function drag(ev) { //當這個事件發生時，去抓到這個元素的id，透過前面的參數"text"傳送。
    ev.dataTransfer.setData("text", ev.target.id);
}

function drop(ev) {
    ev.preventDefault(); //preventDefault：停止物件預設行為
    var data = ev.dataTransfer.getData("text");//"text"作為傳送指令的暗號，需與上面drag的參數相符，才能傳送成功。
    if (ev.target.id == "")
        ev.target.appendChild(document.getElementById(data));
    else
        ev.target.parentNode.appendChild(document.getElementById(data));
}



var sBook = book.children[0];
//console.log(book.children[0]);
var option;
for (var i = 0; i < sBook.children.length; i++) {
    sBook.children[i].draggable = "true";  //讓歌單裡每一首歌都可以抓取(draggable)
    sBook.children[i].id = "song" + (i + 1); //幫歌單裡每一首歌加上id，從1開始
    sBook.children[i].addEventListener('dragstart', function () {//在這段裡function()內不能直接寫函數，所以再用{}寫出需要的函數
        drag(event);
    });
    option = document.createElement("option");//現在沒有option，所以需要用這個函數創建出<option></option>
    option.innerText = sBook.children[i].innerText; //將sBook裡的字樣丟到option裡
    option.value = sBook.children[i].title;  //將sBook裡的title(aka歌曲來源)丟到option裡
    song.appendChild(option); //把歌本裡的歌加進播放清單裡
}
changeMusic(0);

//隱藏歌單
function songBook() {
    book.className = book.className == "" ? "hide" : "";

}




//全曲循環 僅字樣改變 功能寫在getDuration
function setAllLoop() {

    info.children[2].innerText = info.children[2].innerText == "全曲循環" ? "　" : "全曲循環";


}



//隨機播放 僅字樣改變 功能寫在getDuration
function setRandom() {
    info.children[2].innerText = info.children[2].innerText == "隨機播放" ? "　" : "隨機播放";
}


//單曲循環 僅字樣改變 功能寫在getDuration
function setLoop() {
    //if (info.children[2].innerText == "單曲循環")  //原思考路線
    //    info.children[2].innerText = ""
    //else
    //info.children[2].innerText = "單曲循環";

    info.children[2].innerText = info.children[2].innerText == "單曲循環" ? "　" : "單曲循環";
    //audio.loop = !audio.loop; //可縮短到以函數表示即可，若兩邊狀態不相等，則設定相反的功能
    console.log(audio.loop);
}




//靜音
function setMuted() {
    //if (audio.muted)    //原邏輯思考路線，muted為布林值，若現在是靜音，則按下按鈕後解除靜音，若非靜音狀態，則按下按鈕後開始靜音。
    //    audio.muted = false;
    //else
    //audio.muted = true;
    audio.muted = !audio.muted;  //可縮短到以函數表示即可，若兩邊狀態不相等，則設定相反的功能
}



//時間軸
function setTimeBar() {
    audio.currentTime = progress.value;  //音樂已播放的時間=進度條走到的進度
}



//跳到下一首或上一首
function changeSong(i) {
    var index = song.selectedIndex + i;
    if (i == 1 && song.selectedIndex == song.options.length - 1)
        changeMusic(0);
    else if (i == -1 && song.selectedIndex == 0)
        changeMusic(song.options.length - 1);
    else
        changeMusic(index);

}


//歌曲切換
var musicObj, musicIndex = 0;
function changeMusic(i) {


    //musicObj = song.options;
    //musicIndex = song.selectedIndex;
    song.options[i].selected = true; //找到F12的所有歌裡select屬性裡是true的那首歌〈只有播放中的歌是true，其他都是false〉，若沒有寫的話只能從預設的第一首選到下一首，就不能再跳下一首。
    audio.children[0].src = song.options[i].value;//找到歌曲的來源
    audio.children[0].title = song.options[i].innerText;//換掉歌曲的title
    audio.load();  //撥放歌曲

    if (btnPlay.innerText == ";")//利用btnPlay的字義是否改變來決定撥放狀態
        Play();
}




//時間格式轉換
var min = 0, sec = 0, min2 = 0, sec2 = 0;
function getTimeFormat(timeSec) {
    min = parseInt(timeSec / 60);
    sec = parseInt(timeSec % 60);  //取餘數
    //if (min < 10) min = "0" + min;
    //if (sec < 10) sec = "0" + sec;
    min = min < 10 ? "0" + min : min;  //條件：min是否小於10?，若小於就執行"0"+min，若沒有小於就執行min。
    sec = sec < 10 ? "0" + sec : sec;


    return min + ":" + sec;
}



//取得歌曲播放時間

function getDuration() {

    progress.max = parseInt(audio.duration);
    progress.value = parseInt(audio.currentTime);

    var w = (audio.currentTime / audio.duration * 100) + "%";
    progress.style.backgroundImage = "-webkit-linear-gradient(left,#F3E9DD,#F3E9DD " + w + ", #c8c8c8 " + w + ",#c8c8c8)";


    info.children[1].innerText = getTimeFormat(audio.currentTime) + "/" + getTimeFormat(audio.duration);
    setTimeout(getDuration, 10);//在10毫秒後再重新執行getDuration，等於每秒更新歌曲秒數
    if (audio.currentTime == audio.duration) {  //currentTime和duration都是內建函數。currentTime為現在播放到的時間，duration是歌曲總長，都是以秒為單位。
        //有回傳數值
        if (info.children[2].innerText == "隨機播放") {//有回傳數值
           
            var n = Math.floor(Math.random() * song.options.length); //抓song.options.裡面有幾個選項，增加歌之後不用再修改
            changeMusic(n);
        }

        else if //有回傳數值
            (info.children[2].innerText == "全曲循環" && song.selectedIndex == song.options.length - 1) {//&&後的條件為歌曲的index總數=長度-1，因為index從0開始算，length從1開始算，所以length需要-1，意即偵測到最後一首後，將音樂跳回歌單第一首
            
            changeMusic(0); //換到歌單裡第一首歌
        }

        else if (info.children[2].innerText == "單曲循環") {//有回傳數值
            
            changeSong(0);
        }

            //有回傳數值
        else if (song.selectedIndex == song.options.length - 1) {  //若沒有全曲循環，則播到最後一首歌後停止播放
            \            
            Stop();
        }

        else {
            changeSong(1);  //若audio.currentTime = audio.duration，則換下一首〈參數1〉
        }
    }
}



//播放與暫停功能
function Play() {
    if (audio.paused) {   //paused為布林值，初始設定為暫停，所以使用if / else寫條件，現為暫停狀態，所以就寫入播放功能
        audio.play();   //播放音樂的指令〈內建的功能〉
        btnPlay.innerText = ";";    //呼叫上面宣告的變數，將按鍵改為暫停鍵〈因為正在播放中〉
        info.children[0].innerText = "目前播放：" + audio.children[0].title;  //執行info內第一個子節點〈跑馬燈顯示音樂播放〉，再加上audio內第一個子節點〈第一首歌〉的title
        getDuration();
    }
    else {
        audio.pause();
        btnPlay.innerText = "4";  //將按鍵改為播放鍵〈因為音樂暫停中〉
        info.children[0].innerText = "音樂暫停中";
    }
}

//function Pause() {
//    audio.pause();
//}

//停止播放功能
function Stop() {     //內建的功能沒有stop，所以要自己寫
    audio.pause();    //先進行暫停
    audio.currentTime = 0;  //再使用currentTime讓秒數=0等於回到原點
    btnPlay.innerText = "4";
    info.children[0].innerText = "音樂已停止播放";
}

//快進快退功能
function changeTime(t) {
    audio.currentTime += t;   //將進退5秒設定為參數t，加5秒或加-5秒，只要寫一個function即可
}

//音量微調
function changeVolume(v) {
    //audio.volume += v;
    volValue.value = parseInt(volValue.value) + v;  //若直接寫volValue.value += v，則會將volValue.value視為字串。使用parseInt將該函數宣告為數字，再進行運算。
    setVolume();
}

//音量調整
setVolume();
function setVolume() {
    volinfo.value = volValue.value
    audio.volume = volValue.value / 100;  //將音量除以100等分，所以調整時一次為1

    var z = volValue.value + "%";
    volValue.style.backgroundImage = "-webkit-linear-gradient(left,#DAE5D0,#DAE5D0 " + z + ", #c8c8c8 " + z + ",#c8c8c8)";
}
