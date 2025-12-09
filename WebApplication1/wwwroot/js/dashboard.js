// -------------Scroll_Show_Sidebar_div---------------

function toggleMenu() {
    const menuSub = document.getElementById('menu_self_review_item');
    menuSub.classList.toggle('open');
    menuSub.classList.toggle('menu-item-animating');}


// -------------Scroll_Show_Sidebar_div---------------

const scrollToShowDiv = document.querySelector('.scrollToShow');
const scrollableContainer = document.querySelector('.scrollable-container');

let isHidden = true;

scrollableContainer.addEventListener('scroll', () => {
  if (scrollableContainer.scrollTop > 0 && isHidden) {
    // Scrolling down within the container
    scrollToShowDiv.style.display = 'block';
    isHidden = false;
  } else if (scrollableContainer.scrollTop === 0 && !isHidden) {
    // Scrolled back up to the top of the container
    scrollToShowDiv.style.display = 'none';
    isHidden = true;
  }
});


// -------------Scroll_Diary_Test_Area---------------

const textarea = document.getElementById('tex_area_box');

textarea.addEventListener("keyup", e =>{
   textarea.style.height = "63px";
   let scHeight = e.target.scrollHeight;
   textarea.style.height = `${scHeight}px`;
});




function scrollToBottom() {
  var div = document.querySelector('.app-Diary-body');
  div.scrollTop = div.scrollHeight;
}

// Call the scrollToBottom function when the page loads
window.onload = scrollToBottom;


// -------------Show Diary Search Date---------------

function openNav() {

  document.getElementById("mySidebar").style.width = "250px";
  document.getElementById("main").style.marginLeft = "250px";
}

function closeNav() {
  document.getElementById("mySidebar").style.width = "0";
  document.getElementById("main").style.marginLeft= "0";
}


// --------------------Main Sidebar Panel Js------------------------------

function OpenSideBar(){
  document.getElementById("layout-menu").style.left = "0";
  document.getElementById("layout-menu").style.zIndex = "10000";
  document.getElementById("back_blur").style.filter = "blur(10px)";
}
function Close_side_bar(){
  document.getElementById("layout-menu").style.left = "-280px";
  document.getElementById("layout-menu").style.zIndex = "10000";
  document.getElementById("back_blur").style.filter = "blur(0px)";
}

// --------------------Secondary Header Open and close search boc Js------------------------------

function searchOpen(){
  document.getElementById("search_open").style.display = "none";
  document.getElementById("select_task_type").style.display = "none";
  document.getElementById("search_bx_task").style.display = "block";
  document.getElementById("search_cls").style.display = "block";
}
function searchClose(){
  document.getElementById("search_open").style.display = "block";
  document.getElementById("select_task_type").style.display = "block";
  document.getElementById("search_bx_task").style.display = "none";
  document.getElementById("search_cls").style.display = "none";
  
}


