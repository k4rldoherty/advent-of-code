def main():
    f = open("input.txt", "r")
    left = []
    right = []
    diff = 0
    for line in f:
        line_split = line.split()
        left.append(int(line_split[0]))
        right.append(int(line_split[1]))

    left = sorted(left)
    right = sorted(right)

    for i in range(len(left)):
        diff += abs(left[i] - right[i])

    print(diff)

main()