﻿function drawChart(jsonNomineeNames, jsonVotes, chartName, year = null) {

    // Create the data table.
    let nominees = createNomineesArray(jsonNomineeNames);
    let votes = createVotesObjectArray(jsonVotes);
    if (year != null) {
        votes = votes.filter(function (ele) { return ele["YearOfVote"] === year });
    }
    console.log(votes);
    let groupedVotes = groupVotesByNominee(votes, nominees);
    groupedVotes = Object.values(groupedVotes).map(function (ele, i) {
        return [Object.keys(groupedVotes)[i], ele.length]
    });
    var data = new google.visualization.DataTable();
    data.addColumn('string', 'Nominees');
    data.addColumn('number', 'NumberOfVotes');
    data.addRows(groupedVotes);

    var options = {
        'title': chartName,
        'width': 600,
        'height': 400
    };

    // Instantiate and draw our chart, passing in some options.
    var chart = new google.visualization.PieChart(document.getElementById('chart'));
    chart.draw(data, options);
}

function createNomineesArray(nomineesJsonString) {
    return JSON.parse(nomineesJsonString.replace(/&quot;/g, "\"").replace(/""/g, "\"").replace("&#x27;", "'"));
}

function createVotesObjectArray(votesJsonString) {
    return JSON.parse(votesJsonString.replace(/&quot;/g, "\"").replace(/""/g, "\"").replace(/"{/g, "{").replace(/}"/g, "}").replace("&#x27;", "'"));
}

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
