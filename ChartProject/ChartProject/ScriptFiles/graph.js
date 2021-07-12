$(document).ready(function () {
    $.get("/graph/data", null, function (_response) {
        console.log(_response);

        if (_response.data != null) {

            var arr_selectedEmployees = [];
            var arr_alternative_2 = [];
            var arr_alternative_1 = [];

            //--set circle position with its radius
            var circleX = 3.0;
            var circleY = 3.0;
            var circleR = 0.27;

            //-----Set Technical-Ladder----------
            var arr_technical = [];
            arr_technical.push('');

            for (var i = 0; i < _response.data.technical_levels.length; i++) {
                arr_technical.push(_response.data.technical_levels[i].level + '<br>[' + _response.data.technical_levels[i].level_name + ']');
            }
            //------------------------------------

            //-----Set Leadership-Ladder----------
            var arr_leadership = [];
            arr_leadership.push('');

            for (var i = 0; i < _response.data.leadership_levels.length; i++) {
                arr_leadership.push(_response.data.leadership_levels[i].level + '<br>[' + _response.data.leadership_levels[i].level_name + ']');
            }
            //------------------------------------

            //-------Set Employees skills-data-------------
            for (var i = 0; i < _response.data.graph_data.length; i++) {

                var _data = [];
                _data.push(_response.data.graph_data[i].technical_level);
                _data.push(_response.data.graph_data[i].leadership_level);

                //--if greater than "Technical-3rd-Level" & "Leadership-3rd-Level" (Selected-Employees)
                if (_response.data.graph_data[i].technical_level > 3 && _response.data.graph_data[i].leadership_level > 3) {

                    arr_selectedEmployees.push(_data);
                }
                //--if greater than "Technical-2rd-Level" & "Leadership-3rd-Level" (Alternative #2)
                else if (_response.data.graph_data[i].technical_level > 2 && _response.data.graph_data[i].leadership_level > 3) {

                    arr_alternative_2.push(_data);
                }
                //--else (Alternative #1)
                else {
                    arr_alternative_1.push(_data);
                }
            }
            //---------------------------------------------

            function addCircle(chart) {
                if (this.circle) {
                    $(this.circle.element).remove();
                }
                if (this.label) {
                    $(this.label.element).remove();
                }

                var pixelX = chart.xAxis[0].toPixels(circleX);
                var pixelY = chart.yAxis[0].toPixels(circleY);
                var pixelR = chart.xAxis[0].toPixels(circleR) - chart.xAxis[0].toPixels(0);

                this.circle = chart.renderer.circle(pixelX, pixelY, pixelR).attr({
                    fill: 'transparent',
                    stroke: 'black',
                    'stroke-width': 1.6,
                    dashstyle: 'Dot'
                });
                this.circle.add();

                this.label = chart.renderer.label('Target', pixelX - 1.5, pixelY - 20)
                    .attr({
                        zIndex: 4
                    });
                this.label.add();
            }

            $('#container').highcharts({
                chart: {
                    type: 'scatter',
                    zoomType: 'xy',
                    events: {
                        load: function () {
                            addCircle(this);
                        },
                        redraw: function () {
                            addCircle(this);
                        }
                    }
                },
                legend: {
                    align: 'left',
                    verticalAlign: 'top',
                    x: 110
                },
                xAxis: {
                    min: 1,
                    max: 5,
                    gridLineWidth: 1,
                    accessibility: {
                        rangeDescription: 'Range: 0 to 100.',
                    },
                    title: {
                        text: 'Technical Ladder',
                        useHtml: true,
                        style: {
                            color: 'black',
                            fontWeight: 'bold',
                            fontSize: '15px'
                        }
                    },
                    labels: {
                        formatter: function (_val) {
                            if (_val.pos < arr_technical.length) {
                                return arr_technical[_val.pos];
                            }
                            else {
                                return "";
                            }
                        }
                    }
                },
                title: {
                    text: ''
                },
                yAxis: {
                    min: 1,
                    max: 5,
                    startOnTick: false,
                    endOnTick: false,
                    accessibility: {
                        rangeDescription: 'Range: 0 to 100.'
                    },
                    labels: {
                        formatter: function (_val) {
                            if (_val.pos < arr_leadership.length) {
                                return arr_leadership[_val.pos];
                            }
                            else {
                                return "";
                            }
                        }
                    },
                    title: {
                        text: '<b>Leadership Ladder</b>',
                        useHtml: true,
                        style: {
                            color: 'black',
                            fontWeight: 'bold',
                            fontSize: '15px'
                        }
                    },
                },
                tooltip: {
                    formatter: function () {
                        return '<b>' + this.series.name + '</b><br/>Technical: ' + this.x + '<br/>Leadership: ' + this.y;
                    }
                },
                series: [

                    {
                        marker: {
                            radius: 20,
                            symbol: 'circle'
                        },
                        data: arr_selectedEmployees, name: "SelectedEmployee", color: 'red'
                    },
                    {
                        marker: {
                            radius: 20,
                            symbol: 'circle'
                        },
                        data: arr_alternative_1, name: "Alternative #1", color: 'blue'
                    },
                    {
                        marker: {
                            radius: 20,
                            symbol: 'circle'
                        },
                        data: arr_alternative_2, name: "Alternative #2", color: 'purple'
                    }
                ]
            });
        }
    });
});