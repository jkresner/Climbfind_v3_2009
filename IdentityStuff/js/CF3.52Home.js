function IntialiseFeed(channel) 
{
    SetChannel("#AllLnk", 0);
    //SetChannel("#CLnk", 3);
    SetChannel("#PLnk", 2);
    SetChannel("#ArLnk", 1);
    
    SetView("#PoLk", 10);
    SetView("#MLk", 30);
    
    $("#PlaceLink").css('cursor', 'pointer');
    $("#AreaLink").css('cursor', 'pointer');
       
    ChangeChannel(channel)
    InitialiseFeedAreaSelect($("#AreaTxB"));
    InitialiseFeedPlaceSelect($("#Place2TxB"));
    InitiliasePlaceClimbingTxB();

    $('#AddLink').boxy();
    //-- Don't seem to need this: RefreshFeed(); - causes two calls?
}

function SetChannel(link, channel) { $(link).css('cursor', 'pointer'); $(link).click(function() { ChangeChannel(channel); }); }
function SetView(link, view) { $(link).css('cursor', 'pointer'); $(link).click(function() { ChangeView(view); }); }

function RefreshFeed() {
    $("#FeedLoading").show();
    $("#FeedResults").load("/CFFeed/RenderFeed", { channel: $("#CID").val(), view: $("#VID").val(),
        area: $("#AID").val(), place: $("#PID").val(), tag: $("#TID").val()
    }, function() {
        $("#FeedLoading").hide();
        $("#FeedItems").focus();
        imagePreview(); // makes sure that the image hover works again after ajax postback
    });
}

function ChangeChannel(id) {
    var c = "CurrentFilter";
    $("#AllLnk").removeClass(c);
    //$("#CLnk").removeClass(c);
    $("#PLnk").removeClass(c);
    $("#ArLnk").removeClass(c);

    if (id == '0') { $("#AllLnk").addClass(c);  } //$("#CLAct").hide();
    //if (id == '3') { $("#CLnk").addClass(c); $("#CLAct").show(); }
    if (id == '2') { $("#PLnk").addClass(c); } //$("#CLAct").hide(); 
    if (id == '1') { $("#ArLnk").addClass(c);  } //$("#CLAct").hide();

    $("#CID").val(id);
    HideAllFeedFilters();
    RefreshFeed();
}

function ChangeView(id) {
    var c = "CurrentFilter";
    $("#MLk").removeClass(c);
    $("#PoLk").removeClass(c);
    if (id == '10') { $("#PoLk").addClass(c); $("#MAct").hide(); }
    if (id == '30') { $("#MLk").addClass(c); $("#MAct").show(); }

    $("#VID").val(id);
    RefreshFeed();
}

function HideAllFeedFilters() {
    $("#SelectArea").hide();
    $("#SelectPlace").hide();
}


function InitiliasePlaceClimbingTxB() {
    var txb = $("#PlaceClimbingTxB");
    AddWaterMark(txb, "Type place name to post to feed", "PlaceClimbingTxBWaterMark");

    txb.autocomplete("/Places/FilterSearch", { scroll: false, minChars: 2, selectFirst: false,
        formatItem: function(data, i, n, value) { return "<img src='" + value.split(",")[0] + "'/> " + value.split(",")[1] + "; " + value.split(",")[2]; },
        formatResult: function(data, value) { return value.split(",")[2]; }
    });

    txb.result(function(event, data, formatted) {
        if (data) {
            if (data[0].split(",")[3] != -1) {
                $("#placeID").val(data[0].split(",")[3]); document.forms[1].submit();
            }
        }
    });
}

function InitialiseFeedAreaSelect(txb) {
    AddWaterMark(txb, "Type city/state/country", "FilterTxBWaterMark");
    $("#AreaLink").bind("click", function(e) { txb.val("Type city/state/country"); HideAllFeedFilters(); $("#SelectArea").show(); });

    txb.autocomplete("/Places/FilterAreaSearch", { scroll: false, minChars: 2, width: 300, selectFirst: false,
        formatItem: function(data, i, n, value) { return "<img src='" + value.split(",")[0] + "'/> " + value.split(",")[1]; },
        formatResult: function(data, value) { return value.split(",")[1]; }
    });

    txb.result(function(event, data, formatted) {
        if (data) {
            if (data[0].split(",")[2] != '-1') {
                $("#ArLnk").text($.trim(data[0].split(",")[1].substr(0, 12)));
                $("#AID").val(data[0].split(",")[2]); $("#SelectArea").hide(); ChangeChannel('1');
            }
        }
    });
}

function InitialiseFeedPlaceSelect(txb) {
    AddWaterMark(txb, "Type name of place", "FilterTxBWaterMark");
    $("#PlaceLink").bind("click", function(e) { txb.val("Type name of place"); HideAllFeedFilters(); $("#SelectPlace").show(); });

    txb.autocomplete("/Places/FilterSearch", { scroll: false, minChars: 2, selectFirst: false,
        formatItem: function(data, i, n, value) { return "<img src='" + value.split(",")[0] + "'/> " + value.split(",")[1] + "; " + value.split(",")[2]; },
        formatResult: function(data, value) { return value.split(",")[2]; }
    });

    txb.result(function(event, data, formatted) {
        if (data) {
            if (data[0].split(",")[3] != '-1') {
                $("#SelectPlace").hide();
                $("#PID").val(data[0].split(",")[3]);
                $("#PLnk").text($.trim(data[0].split(",")[1].substr(0, 12)));
                ChangeChannel('2');
            }
        }
    });
}
