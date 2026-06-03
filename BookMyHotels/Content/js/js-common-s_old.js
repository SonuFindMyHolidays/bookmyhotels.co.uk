


//--------------Calender Validations Code Begin--------------------
function validateForm() {
    let x = document.forms["myForm"]["datepicker"].value;
    if (x == "") {
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
});


//Top to href function
$(document).ready(function () {
    // Add smooth scrolling to all links
    $("a").on('click', function (event) {

        // Make sure this.hash has a value before overriding default behavior
        if (this.hash !== "") {
            // Prevent default anchor click behavior
            event.preventDefault();

            // Store hash
            var hash = this.hash;

            // Using jQuery's animate() method to add smooth page scroll
            // The optional number (800) specifies the number of milliseconds it takes to scroll to the specified area
            $('html, body').animate({
                scrollTop: $(hash).offset().top
            }, 800, function () {

                // Add hash (#) to URL when done scrolling (default click behavior)
                window.location.hash = hash;
            });
        } // End if
    });
});


// 27-09-2021 code for travellers dropdown

$(".DropdownClass").change(function () {
    if ($(this).attr('name') == 'Count') {
        var number = $(this).val();

        $('.CommonAttribute').hide().slice(0, number).show();
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
window.onload = function () {
    var subjectSel = document.getElementById("rooms");

    var topicSel = document.getElementById("adults");
    for (var x in subjectObject) {
        subjectSel.options[subjectSel.options.length] = new Option(x, x);
    }
    subjectSel.onchange = function () {
        //empty Chapters- and Topics- dropdowns
        $('#adults').find('option').remove();
        var noofroom = parseInt($("#rooms").val())*2;
        for (var i = 0; i < noofroom; i++) {
            $("#adults").append('<option value="' + parseInt(i + 1) + '">' + parseInt(i+1) + '</option>');
        }
            
        $('#selectModelNumber').find('option').remove();
        $("#selectModelNumber").append('<option value="0">0</option>');
        var noofroom = parseInt($("#rooms").val()) * 2;
        for (var i = 0; i < noofroom; i++) {
            $("#selectModelNumber").append('<option value="' + parseInt(i + 1) + '">' + parseInt(i + 1) + '</option>');
            if (i == 7) {
                break;
            }
        }
    }
}

// Select Jquery Code
$(document).ready(function () {
    $('#rooms').click(function () {
        $("#spanrooms").html($("#rooms :selected").html());
    });

    $('#adults').click(function () {
        $("#spanadults").html($("#adults :selected").html());
    });

    $('#selectModelNumber').click(function () {
        $("#spanchild").html($("#selectModelNumber :selected").html());
    });

    var selectValues = {
        "1": "1",
        "2": "2"
    };
    var $mySelect = $('#adults');
    //
    $.each(selectValues, function (key, value) {
        var $option = $("<option/>", {
            value: key,
            text: value
        });
        $mySelect.append($option);
    });
    $("#spanrooms").html(1);
    $("#spanadults").html($("#adults :selected").html());
});
