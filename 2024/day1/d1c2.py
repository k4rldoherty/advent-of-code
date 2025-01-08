def main():
    f = open("input.txt", "r")
    ans = 0
    left = []
    right_occurances = {}
    for line in f:
        line_split = line.split()
        l = int(line_split[0])
        r = int(line_split[1])
        left.append(l)
        if r in right_occurances:
            right_occurances[r] += 1
        else:
            right_occurances[r] = 1

    for num in left:
        if num in right_occurances:
            ans += (num * right_occurances[num])
        else:
            continue

    print(ans)
    

    
main()