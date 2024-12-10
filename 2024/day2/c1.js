const fs = require("fs");
const { argv } = require("process");
const readline = require("readline");
let file;

if (process.argv.length == 2) {
  file = "testinput.txt";
} else if (argv[2] == "-s") {
  file = "input.txt";
} else {
  console.log(
    "Useage - node <file> OPTIONAL '-s' (for submitting with real test data)"
  );
  return;
}

function isReportSafe(line) {
  let lineArr = line.split(" ");
  let increasing = Number.parseInt(lineArr[0]) < Number.parseInt(lineArr[1]);
  for (let i = 0; i < lineArr.length - 1; i++) {
    let curr = Number.parseInt(lineArr[i]);
    let next = Number.parseInt(lineArr[i + 1]);
    if (curr === next || Math.abs(curr - next) > 3) return false;

    if (increasing && curr > next) return false;
    else if (!increasing && curr < next) return false;
  }
  return true;
}

const getSafe = async () => {
  let numSafe = 0;
  const filestream = fs.createReadStream(file);
  const rl = readline.createInterface({
    input: filestream,
  });

  // Read each line (await was needed - research more on this)
  for await (const line of rl) {
    if (isReportSafe(line)) {
      numSafe++;
    }
  }

  return numSafe;
};

getSafe().then((numSafe) => {
  console.log(numSafe);
});
