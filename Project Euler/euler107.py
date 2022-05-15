networkFile = open("/home/carson/Documents/Scripts/Project Euler/107_network","r")
networkFileLines = networkFile.readlines()
row = 0
col = 0
networkArray = []
connectedPaths = []
completeBool = False
boolCounter = 0
networkWeight = 0
trimmedWeight = 0
for fileLine in networkFileLines:
    fileLineArray = fileLine.split(",")
    arrayText = []
    for fileLineArrayItem in fileLineArray:
        if row > col:
            arrayText.append(int(fileLineArrayItem.strip().replace("-","0")))
            col += 1
            networkWeight += int(fileLineArrayItem.strip().replace("-","0"))
        else:
            arrayText.append(0)
    networkArray.append(arrayText)
    row +=1
    col = 0
#print(networkArray)
for i in range(len(networkArray)):
    arrayText = []
    for j in range(len(networkArray[i])):
        if i == j:
            arrayText.append(1000)
        else:
            arrayText.append(1000)
    connectedPaths.append(arrayText)
#print(connectedPaths)

currentMin = 1000
lastMin = -1
while completeBool == False:
    for i in range(len(networkArray)):
        for j in range(len(networkArray[i])):
            if networkArray[i][j] != 0 and networkArray[i][j] < currentMin and networkArray[i][j]  > lastMin:
                currentMin = networkArray[i][j]
    #print(currentMin)
    #print("\n")
    lastMin = currentMin
    for i in range(len(networkArray)):
        for j in range(len(networkArray[i])):
            if networkArray[i][j] == currentMin and connectedPaths[i][j] == 1000:
                connectedPaths[i][j] = currentMin
                connectedPaths[j][i] = currentMin
    #print(connectedPaths)
    #print("\n")
    for i in range(len(connectedPaths)):
        for j in range(len(connectedPaths[i])):
            if connectedPaths[i][j] != 1000:
                for k in range(len(connectedPaths[j])):
                    if i != k and j != k:
                        if max(connectedPaths[i][k], connectedPaths[j][k]) == 1000 and min(connectedPaths[i][k], connectedPaths[j][k]) != 1000:
                            connectedPaths[j][k] = min(connectedPaths[i][k], connectedPaths[j][k])
                            #print(connectedPaths)
                            #print("\n")
    for i in range(len(connectedPaths[0])):
        if connectedPaths[0][i] == 1000:
            boolCounter += 1
        else:
            trimmedWeight += connectedPaths[0][i]
    if boolCounter == 1:
        completeBool = True
    else:
        boolCounter = 0
        trimmedWeight = 0
    currentMin = 1000
    print(connectedPaths)
    print("\n")
print(networkWeight-trimmedWeight)
print("\n")