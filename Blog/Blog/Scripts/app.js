﻿$(document).ready(function () {


    //HOW TO SUBSCRIBE AN OBJECT TO AN EVENT
    //var masterPageError = { errorDiv: $('#masterErrorDiv'), errorLabel: $('#masterErrorText') };
    ////YOU MUST "install" THE OBJECT TO THE mediator
    //mediator.installTo(masterPageError);
    //masterPageError.subscribe('masterPageError', function (arg) {
    //    this.errorDiv.show();
    //    this.errorLabel.html(arg.error + ' ' + arg.method + '<br/> - This text is added to error and is responce to the published event masterPageError - Responding object is located in _Layout');
    //});
    //****************************** START CORE APPLIACTION ERROR LOGGING *********************************//

    //ERROR LOGGING - this must be first so i can respond to subscribed events
    var masterPageError = { errorDiv: $('#masterErrorDiv'), errorLabel: $('#masterErrorText') };
    mediator.installTo(masterPageError);
    masterPageError.subscribe('masterPageError', function (arg) {
        this.errorDiv.show();
        this.errorLabel.html(arg.error + ' ' + arg.method + '<br/> - This text is added to error and is responce to the published event masterPageError - Responding object is located in _Layout');
        // alert('In responce to the masterPageError event.  This message is genrated by the errorLogging object in core.js.  This object is used to make ajax calls to record javascript and other page errors. Here are the extra parms passed -- -- ' + arg.error + ' ' + arg.method);
        //console.log('json post to record error ' + arg.error + ' ' + arg.method);
        //this.name = arg;
        //console.log(this.name + ' obj bttom');
        //alert('obj eveent sub change ' + this.name);
    });

    var pageError = { errorDiv: $('#pageErrorDiv'), errorLabel: $('#pageErrorText') };
    mediator.installTo(pageError);
    pageError.subscribe('pageError', function (arg) {
        this.errorDiv.show();
        this.errorLabel.html(arg.error + ' ' + arg.method);
        //   alert('In responce to the pageError event.  This message is genrated by the errorLogging object in core.js.  This object is used to make ajax calls to record javascript and other page errors. Here are the extra parms passed -- -- ' + arg.error + ' ' + arg.method);
        //this.name = arg;
        //console.log(this.name + ' obj bttom');
        //alert('obj eveent sub change ' + this.name);
    });

    var errorLogging = {};
    mediator.installTo(errorLogging);
    errorLogging.subscribe('logError', function (arg) {
        //  alert('In responce to the logError event.  Use this to only log error but not display it to user. -- -- ' + arg.error + ' ' + arg.method);
        //this.name = arg;
        alert(this.name + ' obj bttom');
        //alert('obj eveent sub change ' + this.name);
    });
    //HOW TO SUBSCRIBE AN OBJECT TO AN EVENT
    //pageError = { errorDiv: $('#pageErrorDiv'), errorLabel: $('#pageErrorText') };
    ////YOU MUST "install" THE OBJECT TO THE mediator
    //mediator.installTo(pageError);
    //pageError.subscribe('pageError', function (arg) {
    //    this.errorDiv.show();
    //    this.errorLabel.html(arg.error + ' ' + arg.method);
    //});

    //****************************** START CORE APPLIACTION SCRIPTS *********************************//

    ////************ MAIN NAV *********************////

    //$('#MainNavProjects, #MainNavProducts, ' +
    //  '#MainNav-Water, #MainNav-Shelter, #MainNav-Food, #MainNav-Med, #MainNav-Comm, #MainNav-Mfg').on('mouseleave', function () {
    //      $(this).toggleClass('open');
    //  }
    //);

    //alert(navItem);
 

    var science = {
        left: 0,
        width: 80,
        backgroundColor: '#5DBBCE' 
    };
    var tech = {
        left: 97,
        width: 49,
        backgroundColor: '#A7DBD8' 
    };
    var manufacturing = {
        left: 163,
        width: 157,
        backgroundColor: '#E0E4CC'
    };
    var nature = {
        left: 337,
        width: 73,
        backgroundColor:'#F38630'
    };
    var other = {
        left: 427,
        width: 63,
        backgroundColor: '#FA6900'
    };

    if (navItem != '') {
        setTopNav(navItem);
    } else {
        $('#navSliderItem').width(0);
    }

    $('#mainNav li').mouseenter(function(obj, event) {

        ////USE THIS SCRIPT TO FIND NEW CSS FOR TOP NAV ITEMS
        
        //var itemIndex = $('#mainNav li').index($(this));
        //var cssAddition = 17 * itemIndex;
        //var totalWidth = 0;

        //if (itemIndex > 0) {
        //    $('#mainNav li').each(function(index) {
        //        if (index < itemIndex) {
        //            totalWidth = totalWidth + $(this).width();
        //        }
        //    });
        //}

        //alert("left= " + (totalWidth + cssAddition));
        //alert("width =" + $(this).width());

        setTopNav($(this).find('a').html().toLowerCase());

    }).mouseleave(function(obj, event) {
        //Reset to default nav
        $('#navSliderItem').stop();
        if (navItem != '') {
           setTopNav(navItem);
       } else {
           $('#navSliderItem').animate({
               left: 0,
               width: 0,
               backgroundColor: '#fff'
           }, 500, function () {
               // Animation complete.
           });
       }

    });


    function setTopNav(cssAttributes) {

        var hoverItem = $('#navSliderItem');
        hoverItem.stop();
        switch (cssAttributes) {
            case 'science':
                hoverItem.animate(science, 500, function () {
                    // Animation complete.
                });
                break;
            case 'tech':
                hoverItem.animate(tech, 500, function () {
                    // Animation complete.
                });
                break;
            case 'manufacturing':
                hoverItem.animate(manufacturing, 500, function () {
                    // Animation complete.
                });
                break;
            case 'nature':
                hoverItem.animate(nature, 500, function () {
                    // Animation complete.
                });
                break;
            case 'other':
                hoverItem.animate(other, 500, function () {
                    // Animation complete.
                });
                break;
        }
    }

    //ADD COMMENT METHOD
    $('#btnSubmitComment').click(function () {

        var comment = {
            ArticleId: $('#articleId').val(),
            PosterName: $('#txtPosterName').val(),
            PosterEmail: $('#txtPosterEmail').val(),
            PosterWebSite: $('#txtPosterWebSite').val(),
            CommentText: $('#txtCommentText').val()
        }

        if (comment.PosterName == '') {
            alert('Post Name is required.');
            return;
        }
        if (comment.CommentText == '') {
            alert('Comment Text is required.');
            return;
        }

        $.ajax({
            url: GetRootURL() + 'Home/PostComment',
            data: JSON.stringify(comment),
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                if (data.success) {
                    //loadingDiv.hide();
                    //mediator.publish('BetLoadDone', {});
                } else {
                    //show error
                    mediator.publish('pageError', { error: data.message, method: 'Insert Comment' });
                }
            },
            error: function () {
                mediator.publish('logError', { error: 'Error with service for inserting comment', method: 'Insert Comment' });
            }
        });

    });

    //**************************** SETS ACTIVE COLOR FOR TOP NAVIGATION
    //try {
    //    //topNavSelectedId is set in _Layout using the viewbag set in the controler.  PageBaseModel.ActiveTopNavLink
    //    $(topNavSelectedId).addClass('active');
    //} catch (err) {
    //    mediator.publish('logError', { error: err.message, method: 'core.js, Active color navigation init.' });
    //}

    var tagCatIndex = 0;
    var tagCatTotal = ($('.tagCat').length -1);
  
    var tagCatdirection = -1;
    $('.navArrow').click(function() {

        if ($(this).attr('direction') == 'right') {
            tagCatdirection = 1;
        } else {
            tagCatdirection = -1;
        }
        $('.tagCat').hide();
        $('.tagCatList').hide();
        tagCatIndex = tagCatIndex + tagCatdirection;
        if (tagCatIndex > tagCatTotal) {
            tagCatIndex = 0;
        }
        if (tagCatIndex < 0) {
            tagCatIndex = tagCatTotal;
        }
        //alert(tagCatIndex);
        $('.tagCat:eq(' + tagCatIndex + ')').show();
        $('.tagCatList:eq(' + tagCatIndex + ')').show();
 
    });

    //*************************** SETS ALL TREEVIEW CONTROLS *********************************//
    try {
        $('.treeView').each(function (index) {
            $(this).treeview({
                persist: "location",
                collapsed: true,
                unique: true
            });
        });
    } catch (err) {
        mediator.publish('logError', { error: err.message, method: 'core.js, Tree View Init' });
    }

    //Global Function to 'stringigy' the object becuase jqueries .ajax post doesn't honor it's content type setting
    //and doesn't send json formated data.
    function sendJsonFormat() {
        return JSON.stringify(this);
    }

    //easy load function for models using form data.  
    //For this to work the ID of the inputs must match this  property names in the model.
    function easyLoad(obj, formData) {
        for (var i in obj) {
            //the  property has not been set so find it in form data
            if (obj[i] == undefined) {
                //MAYBE CHANGE THIS TO A CASE STATMENT FOR THE TYPE VALUE
                if (formData.find('#' + i).attr('type') == 'checkbox') {
                    obj[i] = formData.find('#' + i).is(':checked').toString();
                } else {
                    obj[i] = formData.find('#' + i).val();
                }
            }

            //object has another base object so run it's easyload function
            //this could be change to just do some recursion with it's self
            //...but this way mabye better if an object want custom code to be in it's easylaod
            if (obj[i] == 'object') {
                obj[i].EasyLoad(obj[i], formData);
            }
        }
    }

    //USAGE:
    //var savedSearchId = GetQueryString('queryStringId');
    //RETURNS:String - Get query string from URL
    function GetQueryString(key, default_) {
        if (default_ == null) default_ = "";
        key = key.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
        var regex = new RegExp("[\\?&]" + key + "=([^&#]*)");
        var qs = regex.exec(window.location.href);
        if (qs == null)
            return default_;
        else

            return decodeURIComponent(qs[1].replace(/\+/g, " "));

    };

    //masterPageError.publish('masterPageError', { error: 'INDEX VIEW PAGE CLICK ERROR', method: 'Error is rased in Index View, on link click. -- TEXT CHANGED -- This message is displayed by the masterPageError object in located in _Layout' });
    //pageError.publish('pageError', { error: 'INDEX VIEW PAGE CLICK ERROR', method: ' Error is rased in Index view and is handeled in the Index view' });
    //pageError.publish('logError', { error: 'INDEX VIEW PAGE CLICK ERRORr', method: 'only log error, no responce to page elements.' });

    //mediator.publish('masterPageError', { error: err.message, method: 'core.js, on document ready' });

});