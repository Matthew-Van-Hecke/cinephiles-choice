"use strict";
function displayChartData(jsonVotes, nominees) {
    //let groupedVotes = groupVotesByNominee(jsonVotes);
    var ctx = document.getElementById('voting-stats').getContext('2d');
    var myChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: nominees,
            datasets: [{
                label: '# of Votes',
                data: Object.values(groupVotesByNominee(jsonVotes, nominees)).map(function (ele) { return ele.length }),
                backgroundColor: [
                    'rgba(255, 99, 132, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(255, 206, 86, 0.2)',
                    'rgba(75, 192, 192, 0.2)',
                    'rgba(153, 102, 255, 0.2)',
                    'rgba(255, 159, 64, 0.2)'
                ],
                borderColor: [
                    'rgba(255, 99, 132, 1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(255, 206, 86, 1)',
                    'rgba(75, 192, 192, 1)',
                    'rgba(153, 102, 255, 1)',
                    'rgba(255, 159, 64, 1)'
                ],
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }]
            }
        }
    });
    var myChartB = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: nominees,
            datasets: [{
                label: '# of Votes B',
                data: Object.values(groupVotesByNominee(jsonVotes, nominees)).map(function (ele) { return ele.length }),
                backgroundColor: [
                    'rgba(255, 99, 132, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(255, 206, 86, 0.2)',
                    'rgba(75, 192, 192, 0.2)',
                    'rgba(153, 102, 255, 0.2)',
                    'rgba(255, 159, 64, 0.2)'
                ],
                borderColor: [
                    'rgba(255, 99, 132, 1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(255, 206, 86, 1)',
                    'rgba(75, 192, 192, 1)',
                    'rgba(153, 102, 255, 1)',
                    'rgba(255, 159, 64, 1)'
                ],
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }]
            }
        }
    });
};
function groupVotesByNominee(votesArray, nominees) {
    let groupedArray = {};
    for (let i = 0; i < nominees.length; i++) {
        groupedArray[nominees[i]] = [];
    }
    for (let i = 0; i < votesArray.length; i++) {
        groupedArray[votesArray[i]["Nominee"]].push(votesArray[i]);
    }
    return groupedArray;
}