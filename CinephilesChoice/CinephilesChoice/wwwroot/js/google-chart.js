function drawChart(jsonNomineeNames, jsonVotes, chartName, yourVote, year = null) {

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
        'width': 800,
        'height': 500,
        is3D: true,
        'backgroundColor': {
            'fill': 'none'
        },
        'chartArea': {
            'height':700
        },
        'tooltip': {
            'ignoreBounds': true
        }
    };

    // Instantiate and draw our chart, passing in some options.
    var chart = new google.visualization.PieChart(document.getElementById('chart'));
    chart.draw(data, options);
    document.getElementById("your-vote").innerText = "Your Vote - " + yourVote;
}

function createNomineesArray(nomineesJsonString) {
    return JSON.parse(nomineesJsonString.replace(/&quot;/g, "\"").replace(/""/g, "\"").replace(/&#x27;/g, "'"));
}

function createVotesObjectArray(votesJsonString) {
    return JSON.parse(votesJsonString.replace(/&quot;/g, "\"").replace(/""/g, "\"").replace(/"{/g, "{").replace(/}"/g, "}").replace(/&#x27;/g, "'"));
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
