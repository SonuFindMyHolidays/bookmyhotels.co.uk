


//--------------Calender Validations Code Begin--------------------
function validateForm() {
    let a = document.forms["frmsearch"]["location"].value;
    if (a == "") {
        alert("Please Enter City");
        return false;
    }
    let x = document.forms["frmsearch"]["datepicker"].value;
    let h = document.forms["frmsearch"]["hdndate"].value;
    if (x == "" && h == "") {
        alert("Check-in & Check-out dates must be filled out");
        return false;
    }
}

//--------------Calender Validations Code Begin--------------------



//--------------Add child JS CODE BEGIN--------------------

$(function () {


    $('#test').click(function () {
        $('#testdiv').append('<select name="LIVINGSTYLE" id="test" class="user_data">' +
            '<option value="1">1</option>' +
            '<option value="2">2</option>' +
            '<option value="3">3</option>' +
            '<option value="4">4</option>' +
            '<option value="4">5</option>' +
            '<option value="4">6</option>' +
            '<option value="4">7</option>' +
            '<option value="4">8</option>' +
            '<option value="4">9</option>' +
            '<option value="4">10</option>' +
            '<option value="4">11</option>' +
            '<option value="4">12</option>' +
            '<option value="4">13</option>' +
            '<option value="4">14</option>' +
            '<option value="4">15</option>' +
            '<option value="4">16</option>' +
            '<option value="4">17</option>' +
            '</select>');

    });
    $('#testremove').click(function () {

        $('.user_data').remove();

    });


});

//--------------Add child JS CODE END--------------------


$(document).on('ready', function () {
    // initialization of header
    $.HSCore.components.HSHeader.init($('#header'));

    // initialization of google map
    function initMap() {
        $.HSCore.components.HSGMap.init('.js-g-map');
    }

    // initialization of unfold component
    $.HSCore.components.HSUnfold.init($('[data-unfold-target]'));

    // initialization of toggle state
    $.HSCore.components.HSToggleState.init('.js-toggle-state');

    // initialization of show animations
    $.HSCore.components.HSShowAnimation.init('.js-animation-link');

    // initialization of datepicker
    $.HSCore.components.HSRangeDatepicker.init('.js-range-datepicker');

    // initialization of forms
    $.HSCore.components.HSRangeSlider.init('.js-range-slider');

    // initialization of malihu scrollbar
    $.HSCore.components.HSMalihuScrollBar.init($('.js-scrollbar'));

    // initialization of select
    $.HSCore.components.HSSelectPicker.init('.js-select');

    // initialization of quantity counter
    $.HSCore.components.HSQantityCounter.init('.js-quantity');

    // initialization of slick carousel
    $.HSCore.components.HSSlickCarousel.init('.js-slick-carousel');

    // initialization of go to
    $.HSCore.components.HSGoTo.init('.js-go-to');

    /// news letter ajax call


});



// 27-09-2021 code for travellers dropdown

$(".DropdownClass").change(function () {
    if ($(this).attr('name') == 'room-1-childs') {
        var number = $(this).val();
        $('.CommonAttribute').hide().slice(0, number).show();
    }
});


//Room 2 Child Code Begin

$(".DropdownClass_02").change(function () {
    if ($(this).attr('name') == 'room-2-childs') {
        var number = $(this).val();

        $('.CommonAttribute_02').hide().slice(0, number).show();
    }

});

$(".DropdownClass_03").change(function () {
    if ($(this).attr('name') == 'room-3-childs') {
        var number = $(this).val();

        $('.CommonAttribute_03').hide().slice(0, number).show();
    }

});

$(".DropdownClass_04").change(function () {
    if ($(this).attr('name') == 'room-4-childs') {
        var number = $(this).val();

        $('.CommonAttribute_04').hide().slice(0, number).show();
    }

});



// 27-09-2021 Rooms & Adults according code begin

var subjectObject = {
    "1": {
        "1": [""],
        "2": [""]


    },


    "2": {
        "1": [""],
        "2": [""],
        "3": [""],
        "4": [""]
    },
    "3": {
        "1": [""],
        "2": [""],
        "3": [""],
        "4": [""],
        "5": [""],
        "6": [""]
    },
    "4": {
        "1": [""],
        "2": [""],
        "3": [""],
        "4": [""],
        "5": [""],
        "6": [""],
        "7": [""],
        "8": [""]
    },
    "5": {
        "1": [""],
        "2": [""],
        "3": [""],
        "4": [""],
        "5": [""],
        "6": [""],
        "7": [""],
        "8": [""],
        "9": [""],
        "10": [""]
    },
    "6": {
        "1": [""],
        "2": [""],
        "3": [""],
        "4": [""],
        "5": [""],
        "6": [""],
        "7": [""],
        "8": [""],
        "9": [""],
        "10": [""],
        "11": [""],
        "12": [""]
    },
    "7": {
        "1": [""],
        "2": [""],
        "3": [""],
        "4": [""],
        "5": [""],
        "6": [""],
        "7": [""],
        "8": [""],
        "9": [""],
        "10": [""],
        "11": [""],
        "12": [""],
        "13": [""],
        "14": [""]

    },
    "8": {
        "1": [""],
        "2": [""],
        "3": [""],
        "4": [""],
        "5": [""],
        "6": [""],
        "7": [""],
        "8": [""],
        "9": [""],
        "10": [""],
        "11": [""],
        "12": [""],
        "13": [""],
        "14": [""],
        "15": [""],
        "16": [""]
    }
}



// Select Jquery Code
$(document).ready(function () {
    $('#dv_rem_2').click(function () {
        //total = parseInt(Number($('#topic').val())) + parseInt(Number($('#selectModelNumber').val()) - parseInt($('#totalpaxes').html()));
        //   $("#totalpaxes").html((total));
        $('#topic02').val('0');
        $('#selectModelNumber02').val('0');
        $('#room_02_ch01').detach();
        $('#child0202').detach();
        $('#child0201').detach();


        $('#room_02_ch02').detach();


        // $("#price").load();



    });


    $('#dv_rem_3').click(function () {
        // total = parseInt(Number($('#topic').val())) + parseInt(Number($('#topic02').val())) + parseInt(Number($('#selectModelNumber02').val())) + parseInt(Number($('#selectModelNumber').val()) - parseInt($('#totalpaxes').html()));
        // $("#totalpaxes").html((total));
        $('#topic03').val('0');
        $('#selectModelNumber03').val('0');
        // $("#price").load();
        $('#room_03_ch01').detach();
        $('#child0301').detach();
        $('#child0302').detach();


        $('#room_03_ch02').detach();



    });

    $('#dv_rem_4').click(function () {
        //total = parseInt(Number($('#topic02').val())) + parseInt(Number($('#topic03').val())) + parseInt(Number($('#topic').val())) + parseInt(Number($('#selectModelNumber02').val())) + parseInt(Number($('#selectModelNumber03').val())) + parseInt(Number($('#selectModelNumber').val()) - parseInt($('#totalpaxes').html()));
        //$("#totalpaxes").html((total));

        $('#topic04').val('0');
        $('#selectModelNumber04').val('0');
        // $("#price").load();

        $('#room_04_ch01').detach();
        $('#child0401').detach();
        $('#child0402').detach();
        $('#room_04_ch02').detach();
    });




    $('#myBtn01').click(function () {
        $("#spanadults").html((2));
    });

    $('#dv_rem_2').click(function () {
        $("#spanadults").html((1));
    });


    $('#myBtn03').click(function () {
        $("#spanadults").html((3));
    });
    $('#dv_rem_3').click(function () {
        $("#spanadults").html((2));
    });

    $('#myBtn04').click(function () {
        $("#spanadults").html((4));
    });

    $('#dv_rem_4').click(function () {
        $("#spanadults").html((3));
    });
});



//-------------------------------Hotel Search Widget Js Start from here-------------

function myFunction01() {
    var dots01 = document.getElementById("dots01");
    var moreText01 = document.getElementById("more01");

    var btnText01 = document.getElementById("myBtn01");
    // var addroom01 = document.getElementById("addroom02");

    if (dots01.style.display === "none") {
        btnText01.style.display = "block";
        dots01.style.display = "inline";
        btnText01.innerHTML = "Add another room";
        moreText01.style.display = "none";
        // addroom01.style.display = "none";
        $("#hdnrooms").val(parseInt($("#hdnrooms").val()) - 1);
        calculatepax();

    } else {
        btnText01.style.display = "none";
        dots01.style.display = "none";
        btnText01.innerHTML = "Remove room";
        moreText01.style.display = "inline";
        // addroom01.style.display = "block";
        $("#hdnrooms").val(parseInt($("#hdnrooms").val()) + 1);
        calculatepax();
    }

}

function myFunction03() {

    var dots03 = document.getElementById("dots03");
    var moreText03 = document.getElementById("more03");
    var btnText03 = document.getElementById("myBtn03");
    //var addroom03 = document.getElementById("addroom03");
    var dnone = document.getElementById("dv_rem_2");


    if (dots03.style.display === "none") {
        dnone.style.display = "block";
        btnText03.style.display = "block";
        dots03.style.display = "inline";
        btnText03.innerHTML = "Add another room";
        moreText03.style.display = "none";
        // addroom03.style.display = "none";
        $("#hdnrooms").val(parseInt($("#hdnrooms").val()) - 1);
        calculatepax();

    } else {
        dnone.style.display = "none";
        btnText03.style.display = "none";
        dots03.style.display = "none";
        btnText03.innerHTML = "Remove room";
        moreText03.style.display = "inline";
        // addroom03.style.display = "block";
        $("#hdnrooms").val(parseInt($("#hdnrooms").val()) + 1);
        calculatepax();
    }
}

function myFunction04() {

    var dots04 = document.getElementById("dots04");
    var moreText04 = document.getElementById("more04");
    var btnText04 = document.getElementById("myBtn04");
    // var addroom04 = document.getElementById("addroom04");
    var dnone03 = document.getElementById("dv_rem_3");

    if (dots04.style.display === "none") {
        dnone03.style.display = "block";
        btnText04.style.display = "block";
        dots04.style.display = "inline";
        btnText04.innerHTML = "Add another room";
        moreText04.style.display = "none";
        // addroom04.style.display = "none";
        $("#hdnrooms").val(parseInt($("#hdnrooms").val()) - 1);
        calculatepax();
    } else {
        dnone03.style.display = "none";
        btnText04.style.display = "none";
        dots04.style.display = "none";
        btnText04.innerHTML = "Remove room";
        moreText04.style.display = "inline";
        //addroom04.style.display = "block";
        $("#hdnrooms").val(parseInt($("#hdnrooms").val()) + 1);
        calculatepax();
    }
}

function calculatepax() {
    var hdnrooms = parseInt($('#hdnrooms').val());
    var a = 0;
    for (var i = 0; i < hdnrooms; i++) {
        var adult = document.getElementsByName("room-" + (i + 1) + "-adults")[0].value;
        var child = document.getElementsByName("room-" + (i + 1) + "-childs")[0].value;
        a += parseInt(adult) + parseInt(child);
    }
    $('#totalpaxes').html(a);
}


//------------------------------- SetSearchVariables-----------------------------

function SetSearchVariables(destination, destCode, daterange, roomInfo, totalrooms) {
    var traveller = 0;
    //1|2|2-5,13~2|1|1-15
    $("#location").val(destination);
    $("#hdnlocation").val(destCode);
    $("span.ui-autocomplete-clear").removeAttr("style");
    $("#datepicker").attr("placeholder", daterange);
    $("#datepicker").val(daterange);
    $("#hdndate").val(daterange);
    var rooms = roomInfo.split("~");

    //1|2|2-5,13
    //2|1|1-15

    for (i = 0; i < rooms.length; i++) {
        var r = rooms[i].split("|");
        var c = r[2].split("-");
        if (i == 0) {
            document.getElementsByName("room-" + r[0] + "-adults")[0].value = r[1];
            document.getElementsByName("room-" + r[0] + "-childs")[0].value = c[0];
            var totchild = c[1].split(",");
            traveller = (parseInt(traveller) + parseInt(r[1]) + parseInt(c[0]));

            for (var a = 0; a < parseInt(c[0]); a++) {
                document.getElementById("room-" + r[0] + "-child-" + (a + 1)).style.display = 'block';
                document.getElementById("room-" + r[0] + "-child-" + (a + 1) + "-age").value = totchild[a];
            }

        } else {

            if (i == 1) {
                myFunction01();
            } else if (i == 2) {
                myFunction03();
            } else if (i == 3) {
                myFunction04();
            }
            document.getElementsByName("room-" + r[0] + "-adults")[0].value = r[1];
            document.getElementsByName("room-" + r[0] + "-childs")[0].value = c[0];
            var totchild = c[1].split(",");
            for (var a = 0; a < parseInt(c[0]); a++) {
                document.getElementById("room-" + r[0] + "-child-" + (a + 1)).style.display = 'block';
                document.getElementsByName("room-" + r[0] + "-child-" + (a + 1) + "-age")[0].value = totchild[a];
            }

            traveller = (parseInt(traveller) + parseInt(r[1]) + parseInt(c[0]));
        }
    }

    $("#totalpaxes").html(traveller);
    $("#spanadults").html(rooms.length);
    $("#hdnrooms").val(totalrooms);
}


$(document).ready(function () {
    $("#overview_li").click(function () {

        $('#overview_li').addClass('active');
        $('#rooms_li').addClass('nav-item').removeClass('active');
        $('#amenities_li').addClass('nav-item').removeClass('active');
        //$('#accessibility_li').addClass('nav-item').removeClass('active');
        $('#map_li').addClass('nav-item').removeClass('active');
    });

    $("#rooms_li").click(function () {

        $('#rooms_li').addClass('active');
        $('#overview_li').addClass('nav-item').removeClass('active');
        $('#amenities_li').addClass('nav-item').removeClass('active');
        //$('#accessibility_li').addClass('nav-item').removeClass('active');
        //$('#policies_li').addClass('nav-item').removeClass('active');
        $('#map_li').addClass('nav-item').removeClass('active');
    });
    $("#amenities_li").click(function () {

        $('#amenities_li').addClass('active');
        $('#overview_li').addClass('nav-item').removeClass('active');
        $('#rooms_li').addClass('nav-item').removeClass('active');
        $('#accessibility_li').addClass('nav-item').removeClass('active');
        $('#policies_li').addClass('nav-item').removeClass('active');
        $('#map_li').addClass('nav-item').removeClass('active');
    });

    //$("#accessibility_li").click(function () {

    //    $('#accessibility_li').addClass('active');
    //    $('#overview_li').addClass('nav-item').removeClass('active');
    //    $('#rooms_li').addClass('nav-item').removeClass('active');
    //    $('#amenities_li').addClass('nav-item').removeClass('active');
    //    $('#policies_li').addClass('nav-item').removeClass('active');
    //    $('#map_li').addClass('nav-item').removeClass('active');
    //});
    //$("#policies_li").click(function () {

    //    $('#policies_li').addClass('active');
    //    $('#overview_li').addClass('nav-item').removeClass('active');
    //    $('#rooms_li').addClass('nav-item').removeClass('active');
    //    $('#amenities_li').addClass('nav-item').removeClass('active');
    //    $('#accessibility_li').addClass('nav-item').removeClass('active');
    //    $('#map_li').addClass('nav-item').removeClass('active');
    //});
    $("#map_li").click(function () {

        $('#map_li').addClass('active');
        $('#overview_li').addClass('nav-item').removeClass('active');
        $('#rooms_li').addClass('nav-item').removeClass('active');
        $('#amenities_li').addClass('nav-item').removeClass('active');
        $('#accessibility_li').addClass('nav-item').removeClass('active');
        $('#policies_li').addClass('nav-item').removeClass('active');
    });










    //$("#rooms_li").click(function () {

    //    $('li').addClass('nav-item active').removeClass('nav-item');

    //});

    //$("#overview_li").click(function () {

    //    $(this).css('background-color', '#4297fe');
    //    $(this).css('padding-bottom', '0px');


    //    //$('#pricenew_dv').css('border-bottom', '0px solid #4297fe');
    //    //$('#pricenew_dv').css('padding-bottom', '5px');

    //    //$('#shortne_dv').css('border-bottom', '0px solid #4297fe');
    //    //$('#shortne_dv').css('padding-bottom', '5px');

    //    //$('.top_3_col_icon').css('color', '#4297fe');

    //    //$('.top_3_col_icon_02').css('color', '#aeadad');
    //    //$('.top_3_col_icon_03').css('color', '#aeadad');


    //});



});

//Scroller for Hotel Detail Page
document.addEventListener("DOMContentLoaded", function () {
    const navbarLinks = document.querySelectorAll('.js-sticky-block ul li');
    const sections = document.querySelectorAll('section');

    // Smooth scroll to section on click
    navbarLinks.forEach(link => {
        link.addEventListener('click', () => {
            const targetId = link.getAttribute('data-target');
            const targetSection = document.getElementById(targetId);
            targetSection.scrollIntoView({ behavior: 'smooth' });
        });
    });

    // Highlight active section on scroll
    window.addEventListener('scroll', () => {
        let scrollPosition = document.documentElement.scrollTop || document.body.scrollTop;

        sections.forEach(section => {
            const sectionTop = section.offsetTop;
            const sectionHeight = section.clientHeight;

            // Check if the scroll position is within the section
            if (scrollPosition >= sectionTop && scrollPosition < sectionTop + sectionHeight) {
                navbarLinks.forEach(link => link.classList.remove('active'));
                const activeLink = document.querySelector(`.js-sticky-block ul li[data-target="${section.id}"]`);
                if (activeLink) {
                    activeLink.classList.add('active');
                }
            }

            // Special case for the last section
            if (section === sections[sections.length - 1] && scrollPosition + window.innerHeight >= document.body.scrollHeight) {
                navbarLinks.forEach(link => link.classList.remove('active'));
                const activeLink = document.querySelector(`.js-sticky-block ul li[data-target="${section.id}"]`);
                if (activeLink) {
                    activeLink.classList.add('active');
                }
            }
        });
    });
});


//----------------------------------------Listing Filters-------------------------

function toggleMobileFilter() {
    const filterBox = document.getElementById("filterBox");
    const isOpen = filterBox.classList.contains("active");
    const body = document.body;

    if (isOpen) {
        filterBox.classList.remove("mobile-overlay", "active");
        filterBox.classList.add("desktop-visible");
        body.classList.remove("no-scroll"); // Enable scrolling
    } else {
        filterBox.classList.remove("desktop-visible");
        filterBox.classList.add("mobile-overlay", "active");
        body.classList.add("no-scroll"); // Disable scrolling
    }


}

function ClearFilterMobile() {
    location.reload();
}


//Stepper
//let currentStep = 1;

//function updateStepper() {
//    const steps = document.querySelectorAll(".step");
//    const contents = document.querySelectorAll(".step-content");

//    steps.forEach((step, i) => {
//        step.classList.remove("active", "completed");
//        if (i < currentStep - 1) step.classList.add("completed");
//        else if (i === currentStep - 1) step.classList.add("active");
//    });

//    contents.forEach((content, i) => {
//        content.classList.remove("active");
//        if (i === currentStep - 1) {
//            setTimeout(() => content.classList.add("active"), 10);
//        }
//    });
//    window.scrollTo({ top: 0, behavior: 'smooth' });
//}


//function nextStep() {
//    if (currentStep < 3) {
//        currentStep++;
//        updateStepper();
//    }
//}

//function prevStep() {
//    if (currentStep > 1) {
//        currentStep--;
//        updateStepper();
//    }
//}


//document.getElementById("checkoutForm").addEventListener("submit", function (e) {
//    e.preventDefault();
//    alert("Payment successful!");
//    this.reset();
//    currentStep = 1;
//    updateStepper();
//});


var path = window.location.pathname;

if (path === "/") {
    var words = ["Memories", "City Breaks", "Family", "Kids", "Perfect Stay", "Spa", "Romantic Getaways"];
    var wordEl = document.getElementById("word");
    var wordIndex = 0;
    var charIndex = 0;
    var isDeleting = false;

    function type() {
        const currentWord = words[wordIndex];
        const displayText = currentWord.substring(0, charIndex);

        wordEl.textContent = displayText;

        if (!isDeleting) {
            if (charIndex < currentWord.length) {
                charIndex++;
                setTimeout(type, 120);
            } else {
                isDeleting = true;
                setTimeout(type, 3500); // pause before deleting
            }
        } else {
            if (charIndex > 0) {
                charIndex--;
                setTimeout(type, 60);
            } else {
                isDeleting = false;
                wordIndex = (wordIndex + 1) % words.length;
                setTimeout(type, 300);
            }
        }
    }

    type();
}




//Carousal
var pathTwo = window.location.pathname;

if (pathTwo === "/") {
    window.addEventListener("DOMContentLoaded", function () {
        const blogTrack = document.getElementById("blogCarouselTrack");
        const blogSlides = document.querySelectorAll(".blog-carousel-slide");
        let blogIndex = 0;

        function getBlogSlidesPerView() {
            return window.innerWidth >= 768 ? 3 : 1;
        }

        function moveBlogCarousel(direction) {
            const slidesPerView = getBlogSlidesPerView();
            const maxIndex = blogSlides.length - slidesPerView;

            blogIndex += direction;
            if (blogIndex < 0) blogIndex = 0;
            if (blogIndex > maxIndex) blogIndex = maxIndex;

            const cardWidth = blogSlides[0].offsetWidth;
            blogTrack.style.transform = `translateX(-${blogIndex * cardWidth}px)`;
        }

        window.moveBlogCarousel = moveBlogCarousel; // global for buttons

        window.addEventListener("resize", () => {
            blogIndex = 0;
            blogTrack.style.transform = `translateX(0)`;
        });

        // Touch support
        let startX = 0;
        let endX = 0;

        blogTrack.addEventListener("touchstart", (e) => {
            startX = e.touches[0].clientX;
        });

        blogTrack.addEventListener("touchmove", (e) => {
            endX = e.touches[0].clientX;
        });

        blogTrack.addEventListener("touchend", () => {
            const deltaX = endX - startX;
            if (Math.abs(deltaX) > 50) {
                if (deltaX < 0) {
                    moveBlogCarousel(1); // Swipe left → next
                } else {
                    moveBlogCarousel(-1); // Swipe right → prev
                }
            }
        });
    });
}







//Vibration
function vibrateOnClick(selector) {
    const elements = document.querySelectorAll(selector);

    elements.forEach(el => {
        el.addEventListener('click', () => {
            if (navigator.vibrate) {
                navigator.vibrate(100); // vibrates for 100 milliseconds
            }
        });
    });
}

// Call this when the DOM is ready
document.addEventListener('DOMContentLoaded', () => {
    // Target buttons and links (customize selector if needed)
    vibrateOnClick('a, button');
});

// Add New Guest
if (path.includes("/Hotel/HotelPayment")) {
    document.getElementById('addGuestBtn').addEventListener('click', function (e) {
        e.preventDefault();

        const container = document.getElementById('additionalGuestContainer');

        // Prevent adding more than one guest
        if (container.querySelectorAll('.row').length > 0) {
            alert("You can add only one additional guest.");
            return;
        }

        const guestWrapper = document.createElement('div');
        guestWrapper.classList.add('row', 'g-2', 'mb-3', 'align-items-start');
        guestWrapper.innerHTML = `
          <div class="col-sm-2 mb-2">
            <div class="js-form-message">
                <label class="form-label">
                    Title
                </label>
                <select class="form-control dropdown-select" name="Title_@b" id="Title_@b" required data-error-class="u-has-error" data-success-class="u-has-success"
                        data-live-search="true"
                        data-style="form-control font-size-16 border-width-2 border-gray font-weight-normal">
                    <option value="MR">Mr</option>
                    <option value="MRS">Mrs</option>
                    <option value="MS">Ms</option>
                    <option value="MISS">Miss</option>
                    <option value="DR">Dr</option>
                    <option value="PROF">Prof</option>
                    <option value="REV">Rev</option>
                    <option value="SIR">Sir</option>
                    <option value="HON">Hon</option>
                </select>
            </div>
          </div>
        <div class="col-sm-2 mb-2" style="display:none;">
            <div class="js-form-message">
                <label class="form-label">
                    Gender
                </label>
                <select class="form-control dropdown-select" required name="Gender_@b" id="Gender_@b" data-error-class="u-has-error" data-success-class="u-has-success"
                        data-live-search="true"
                        data-style="form-control font-size-16 border-width-2 border-gray font-weight-normal">
                    <option value="MR" selected>Male</option>
                    <option value="MRS">Female</option>
                </select>
            </div>
        </div>
        <div class="col-sm-3 mb-3">
            <div class="js-form-message">
                <label class="form-label">
                    First Name<span style="color:#ff0000;">*</span>
                </label>
                <input type="text" class="form-control" name="FirstName_@b" id="FirstName_@b" placeholder="(e.g. John)" aria-label="John" required
                        data-msg="Please enter your first name."
                        data-error-class="u-has-error"
                        data-success-class="u-has-success">
            </div>
        </div>
        <div class="col-sm-3 mb-3">
            <div class="js-form-message">
                <label class="form-label">
                    Middle Name
                </label>
                <input type="text" class="form-control" name="MiddleName_@b" id="MiddleName_@b" placeholder="" aria-label=""
                        data-msg="Please enter your middle name."
                        data-error-class="u-has-error"
                        data-success-class="u-has-success">
            </div>
        </div>
        <div class="col-sm-4 mb-4">
            <div class="js-form-message">
                <label class="form-label">
                    Last Name<span style="color:#ff0000;">*</span>
                </label>
                <input type="text" class="form-control" name="LastName_@b" id="LastName_@b" placeholder="(e.g. Smith)" required
                        data-msg="Please enter your last name." data-error-class="u-has-error"
                        data-success-class="u-has-success" />
            </div>
        </div>
        <div class="col-12 text-right">
            <button type="button" class="btn btn-xs btn-outline-danger remove-guest" title="Remove Guest">Remove Guest</button>
        </div>
    `;

        container.appendChild(guestWrapper);
    });

    document.addEventListener('click', function (e) {
        if (e.target.closest('.remove-guest')) {
            e.preventDefault();
            const row = e.target.closest('.row');
            row.remove();
        }
    });
}

function ValidateEmail(emailID) {
    var emailPattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
    if (!emailPattern.test(emailID.value)) {
        alert('Please enter a valid email ID');
        return false;
    }
    return true;
}

//if (path.includes("/")) {
//    const sliderTrack = document.getElementById("sliderTrack");
//    const slides = document.querySelectorAll(".slide");
//    const slideCount = slides.length;
//    let index = 0;

//    function moveToNextSlide() {
//        index++;
//        sliderTrack.style.transition = "transform 0.5s ease-in-out";
//        sliderTrack.style.transform = `translateX(-${index * 100}%)`;

//        // Reset to first slide (without transition)
//        if (index === slideCount - 1) {
//            setTimeout(() => {
//                sliderTrack.style.transition = "none";
//                sliderTrack.style.transform = "translateX(0)";
//                index = 0;
//            }, 500);
//        }
//    }

//    setInterval(moveToNextSlide, 3000);


//}

if (path.includes("/Hotel/HotelPayment") || path.includes("/topdestination/hotels-in-europe")) {
    function toggleInfo(el) {
        const extra = el.nextElementSibling;
        extra.classList.toggle('open');
    }
}

if (path.includes("/Hotel/HotelPayment")) {
    function updateTotal() {
        let total = 0;

        $(".addonCheck:checked").each(function (index) {
            total = total + (parseFloat($(this).val()) * parseFloat($(this).attr("data-quantity")));
        });
        document.getElementById('totalPrice').innerText = total.toFixed(2);
        UpdateTotalPriceWithTripAdd(total);
    }
    function toggleBundle() {
        const bundle = document.getElementById('bundleCheck').checked;
        document.querySelectorAll('.addonCheck').forEach(c => c.checked = bundle);
        updateTotal();
    }

    function UpdateTotalPriceWithTripAdd(total) {
        var IsPGValue = 0.00;
        var Gtotal = $("#RoomPrice").val();
        const isPgCheck = parseInt($("#IsPgChecked").val());
        if (total == 0.00) {
            $("#IsTripAddChecked").val(0);
            $("#TripAddValue").val(0);
            $("#TripaddLI").hide();
            $("#spnTriAdd").html('');

        } else {
            $("#IsTripAddChecked").val(1);
            $("#TripAddValue").val(total.toFixed(2));
            $("#TripaddLI").show();
            $("#spnTriAdd").html('&pound; ' + total.toFixed(2));
        }
        if (isPgCheck === 1) {
            IsPGValue = parseFloat($("#IsPGValue").val());
            $("#spnTotal").html(parseFloat(parseFloat(Gtotal) + parseFloat(IsPGValue) + parseFloat(total)).toFixed(2));

        } else {
            $("#spnTotal").html(parseFloat(parseFloat(Gtotal) + parseFloat(total)).toFixed(2));
        }
        CalculateTotal(parseFloat(Gtotal), total, parseFloat(IsPGValue));
    }

    function CalculateTotal(roomPrice, PgPrice, TripAddPrice) {
        var Total = parseFloat(roomPrice + PgPrice + TripAddPrice);
        $("#GrandTotalPrice").val(Total);
    }


    // Safe parser for any currency/number string
    function toNumber(val) {
        if (typeof val === 'number') return isFinite(val) ? val : 0;
        if (!val) return 0;
        let s = String(val).trim();

        // Handle thousands/decimal separators
        if (s.includes(',') && s.includes('.')) {
            s = s.replace(/,/g, '');
        } else if (s.includes(',') && !s.includes('.')) {
            s = s.replace(/\./g, '');
            s = s.replace(/,/g, '.');
        }

        // Remove currency symbols and other junk
        s = s.replace(/[^\d.-]/g, '');
        const n = parseFloat(s);
        return isNaN(n) ? 0 : n;
    }

    // Calculate TripAdd total from checked boxes
    function currentTripAddTotal() {
        let total = 0;
        document.querySelectorAll('.addonCheck:checked').forEach(c => {
            total += toNumber(c.value);
        });
        return total;
    }

    // Main update function
    function updateTotall() {
        const tripAddTotal = currentTripAddTotal();
        const grandBase = toNumber($("#GrandTotalPrice").val() || $("#GrandTotalPrice").text());
        const refundValue = toNumber($("#IsPGValue").val());
        const refundChecked = $('#refundProtection').is(':checked');

        // Update TripAdd UI
        $("#IsTripAddChecked").val(tripAddTotal > 0 ? 1 : 0);
        $("#TripAddValue").val(tripAddTotal.toFixed(2));
        if (tripAddTotal > 0) {
            $("#TripaddLI").show();
            $("#spnTriAdd").html('&pound; ' + tripAddTotal.toFixed(2));
        } else {
            $("#TripaddLI").hide();
            $("#spnTriAdd").html('');
        }

        // Calculate grand total
        const grand = grandBase + tripAddTotal + (refundChecked ? refundValue : 0);
        $("#spnTotal").html(grand.toFixed(2));

        // Update TripAdd subtotal display
        $("#totalPrice").text(tripAddTotal.toFixed(2));
        //$("#GrandTotalPrice").val(tripAddTotal.toFixed(2));
    }

    // Bundle toggle
    function toggleBundle() {
        const bundle = document.getElementById('bundleCheck').checked;
        document.querySelectorAll('.addonCheck').forEach(c => c.checked = bundle);
        updateTotal();
    }

    // Event bindings
    //$(document).on('change', '.addonCheck', updateTotal);
    //$(document).on('change', 'input[name="refundOption"]', function () {
    //    $("#IsPgChecked").val($(this).val() === '1' ? 1 : 0);
    //    updateTotal();
    //});

    // Init on page load
    //$(function () {
    //    updateTotal();
    //});

}

if (path.includes("/")) {
    var select = document.getElementById('tabSelect');
    var tabs = document.querySelectorAll('#myTab a');
    tabs.forEach(function (tab) {
        var option = document.createElement('option');
        option.value = tab.getAttribute('href');
        option.textContent = tab.textContent.trim();
        if (tab.classList.contains('active')) option.selected = true;
        select.appendChild(option);
    });
    //select.addEventListener('change', function () {
    //    $('#myTab a[href="' + this.value + '"]').tab('show');
    //});
    $('#myTab a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
        select.value = $(e.target).attr('href');
    });
}
