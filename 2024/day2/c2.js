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

function isReportSafe(line, recurse) {
  let increasing = Number.parseInt(line[0]) < Number.parseInt(line[1]);
  for (let i = 0; i < line.length - 1; i++) {
    let curr = Number.parseInt(line[i]);
    let next = Number.parseInt(line[i + 1]);
    if (curr === next || Math.abs(curr - next) > 3)
      return recurse ? isReportSafeWithDampner(line) : false;
    if (increasing && curr > next)
      return recurse ? isReportSafeWithDampner(line) : false;
    else if (!increasing && curr < next)
      return recurse ? isReportSafeWithDampner(line) : false;
  }

  return true;
}

function isReportSafeWithDampner(line) {
  let results = [];
  for (let i = 0; i < line.length; i++) {
    let toRemove = i;
    let newLine = line.slice(0, toRemove).concat(line.slice(toRemove + 1));
    results.push(isReportSafe(newLine, false));
  }
  return results.some((v) => v === true);
}

const getSafe = async () => {
  let numSafe = 0;
  const filestream = fs.createReadStream(file);
  const rl = readline.createInterface({
    input: filestream,
  });

  // Read each line (await was needed - research more on this)
  for await (const line of rl) {
    if (isReportSafe(line.split(" "), true)) {
      numSafe++;
    }
  }

  return numSafe;
};

getSafe().then((numSafe) => console.log(numSafe));
