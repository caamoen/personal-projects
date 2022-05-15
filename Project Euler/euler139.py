import math

pyCount = 0
def findmax(num1, num2):
    if num1 >= num2:
        return num1
    else:
        return num2
def findmin(num1, num2):
    if num1 >= num2:
        return num2
    else:
        return num1
for m in range(1,10000):
    for n in range(1, m):
        if 2* pow(m,2) + 2*m*n > 100000000:
            break
        if (pow(m,2) + pow(n,2)) % abs(pow(m,2) - pow(n,2) - 2*m*n) == 0 and math.gcd(m,n) == 1 and (m % 2 == 0 or n % 2 == 0):
            print(f"({findmin(pow(m,2)-pow(n,2),2*m*n)}, {findmax(pow(m,2)-pow(n,2),2*m*n)}, {pow(m,2) + pow(n,2)})")
            pyCount += math.floor(100000000/(2* pow(m,2) + 2*m*n))
    
print(f"total: {pyCount}")