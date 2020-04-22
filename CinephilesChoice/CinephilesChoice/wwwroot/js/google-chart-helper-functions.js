function createNomineesArray(nomineesJsonString) {
    return JSON.parse(nomineesJsonString.replace(/&quot;/g, "\"").replace(/""/g, "\""));
}

function createVotesObjectArray(votesJsonString) {
    return JSON.parse(votesJsonString.replace(/&quot;/g, "\"").replace(/""/g, "\"").replace(/"{/g, "{").replace(/}"/g, "}"));
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
