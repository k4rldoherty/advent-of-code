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
    argv[2],
    "Useage - node <file> OPTIONAL '-s' (for submitting with real test input)."
  );
  return;
}

const main = async () => {
  const filestream = fs.createReadStream(file);
  const rl = readline.createInterface({
    input: filestream,
  });

  let inputString;
  for await (const line of rl) {
    inputString += line;
  }

  let validFuncCalls = parseString(inputString);

  const answer = calculateAnswer(validFuncCalls);

  console.log(answer);
};

const parseString = (input) => {
  const re = /mul\(\d+\,\d+\)/g;
  let matches = input.match(re);
  const parsedRe = /\d+\,\d+/;
  let result = [];
  matches
    .map((e) => e.match(parsedRe))
    .forEach((e) => result.push(e[0].split(",")));
  return result;
};

const calculateAnswer = (arr) => {
  let total = 0;
  arr.forEach((element) => {
    total += parseInt(element[0]) * parseInt(element[1]);
  });

  return total;
};

main();
