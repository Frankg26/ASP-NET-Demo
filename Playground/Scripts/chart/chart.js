//Function gets the chart data from the controller
function GetChartData() {
    var name = 'Stock';

    $.ajax({
        url: '/Chart/GetChartData',
        type: 'POST',
        dataType: 'json',
        data: {
            name: name
        },
        success: function (retData) {
            //console.log(retData);
            DrawChart(retData);
        },
        error: function (retData) {
            console.log(retData);
        }
    });
}

//Function draws the chart with the Highstock library
function DrawChart(retData) {

    var seriesData = [];
    for (var i = 0; i < retData.ChartData.DateList.length; i++) {
        var date = retData.ChartData.DateList[i];
        var price = retData.ChartData.PriceList[i];

        seriesData.push({
            x: moment.utc(date).valueOf(),
            y: price
        });
    }

    var series = {
        name: 'Stock Price',
        id: "STOCK",
        data: seriesData,
        color: "#7CB9E8",
        type: 'area',
        threshold: null
    }

    //Highstocks takes an array of "series" for plotting
    var seriesArray = [];
    seriesArray.push(series);

    var container = $(".chart-container");
    var chartContainer = document.createElement('div');
    $(chartContainer).addClass('hc-widget');
    $(container).append(chartContainer);

    //Function draws the Chart, there are many options that can be enabled
    //https://api.highcharts.com/highcharts/
    var areaChart = Highcharts.stockChart(chartContainer, {

        title: {
            text: 'Frank\'s Chart'
        },
        credits: {
            text: "Made by Frank Garcia"
        },
        rangeSelector: {
            enabled: false
        },        
        exporting: {
            enabled: false
        },
        navigator: {
            enabled: false
        },
        scrollbar: {
            enabled: false
        },

        tooltip: {
            xDateFormat: '%b %e %Y',
            pointFormat: '<span style="color:{series.color}; font-weight: 700;">{series.name}</span>: <b>${point.y} </b><br/>',
            valueDecimals: 2
        },

        series: seriesArray
    });

}