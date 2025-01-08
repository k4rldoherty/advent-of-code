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
  let parsed = parseString(inputString);
  let answer = calculateAnswer(parsed);
  console.log(answer);
};

const parseString = (input) => {
  const regex = /mul\(\d+\,\d+\)|don't\(\)|do\(\)/g;
  const parsedInput = input.match(regex);
  let enabled = true;
  let toMultiply = [];
  parsedInput.forEach((element) => {
    if (element === "don't()") enabled = false;
    if (element === "do()") enabled = true;
    else {
      if (enabled) {
        const refinedRe = /\d+\,\d+/;
        let refinedElement = element.match(refinedRe); 
        toMultiply.push(refinedElement[0].split(','));
      }
    }
  });
  return toMultiply
};

const calculateAnswer = (arr) => {
    let total = 0;
    arr.map((e) => {
        total += (parseInt(e[0]) * parseInt(e[1]));
    });

    return total;
}

main();
