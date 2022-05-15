import math, sympy
primeList = list(sympy.primerange(0, 100))
print(primeList)
completeBool = False
n = 0
useNumerator = 1
useDenominator = 1

while completeBool == False:
    useDenominator *= primeList[n]
    useNumerator *= (primeList[n] - 1)
    n += 1
    if useNumerator/(useDenominator - 1) < 15499 / 94744:
        completeBool = True
        print("done!")
    print(useDenominator)
    print(str(useNumerator) + " / " + str(useDenominator))
    print(useNumerator/(useDenominator - 1))
j = 223092870
i = 1
while j <= 6469693230:
    j = 223092870
    j = j * i
    print(j)
    
    i += 1
""" import math, sympy
primeList = list(sympy.primerange(0, 100))
current_min = 1
for i in range(2, 100000, 2):
    numeratorCount = 0
    for j in range(1, i, 2):
        if math.gcd(i, j) == 1:
            numeratorCount += 1
    #print(i)
    #print(str(numeratorCount) + " / " + str(i))
    #print(numeratorCount/(i - 1))
    if numeratorCount/(i - 1) < 15499 / 94744:
        print("done!")
    elif numeratorCount/(i - 1) < current_min:
        current_min = numeratorCount/(i - 1)
        print("current min (" + str(i)  + "): " + str(current_min)) """