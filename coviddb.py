import requests
import json
import pandas
import sqlite3

dbConnection = sqlite3.connect("/home/carson/Desktop/covid.db")

#apiCall = "https://covid.ourworldindata.org/data/owid-covid-data.json"
#apiSource = ('https://covid.ourworldindata.org',)
#covidFile = requests.get(apiCall)
#covidJSON = json.loads(covidFile.text)

dbCursor = dbConnection.execute("SELECT MAX(CVC_DATE) FROM COVID_COUNTY;").fetchone()
lastDate = dbCursor[0]

apiCall = "https://raw.githubusercontent.com/nytimes/covid-19-data/master/us-counties.csv"
covidFile = requests.get(apiCall)
covidCSV = pandas.read_csv(apiCall)

stateAbbreviations = {
    'Alabama': 'AL',
    'Alaska': 'AK',
    'American Samoa': 'AS',
    'Arizona': 'AZ',
    'Arkansas': 'AR',
    'California': 'CA',
    'Colorado': 'CO',
    'Connecticut': 'CT',
    'Delaware': 'DE',
    'District of Columbia': 'DC',
    'Florida': 'FL',
    'Georgia': 'GA',
    'Guam': 'GU',
    'Hawaii': 'HI',
    'Idaho': 'ID',
    'Illinois': 'IL',
    'Indiana': 'IN',
    'Iowa': 'IA',
    'Kansas': 'KS',
    'Kentucky': 'KY',
    'Louisiana': 'LA',
    'Maine': 'ME',
    'Maryland': 'MD',
    'Massachusetts': 'MA',
    'Michigan': 'MI',
    'Minnesota': 'MN',
    'Mississippi': 'MS',
    'Missouri': 'MO',
    'Montana': 'MT',
    'Nebraska': 'NE',
    'Nevada': 'NV',
    'New Hampshire': 'NH',
    'New Jersey': 'NJ',
    'New Mexico': 'NM',
    'New York': 'NY',
    'North Carolina': 'NC',
    'North Dakota': 'ND',
    'Northern Mariana Islands':'MP',
    'Ohio': 'OH',
    'Oklahoma': 'OK',
    'Oregon': 'OR',
    'Pennsylvania': 'PA',
    'Puerto Rico': 'PR',
    'Rhode Island': 'RI',
    'South Carolina': 'SC',
    'South Dakota': 'SD',
    'Tennessee': 'TN',
    'Texas': 'TX',
    'Utah': 'UT',
    'Vermont': 'VT',
    'Virgin Islands': 'VI',
    'Virginia': 'VA',
    'Washington': 'WA',
    'West Virginia': 'WV',
    'Wisconsin': 'WI',
    'Wyoming': 'WY'
}
for index, covidData in covidCSV.iterrows():
    if covidData["date"] > lastDate or lastDate is None:
        sqlParameters = [covidData["date"], covidData["county"], stateAbbreviations[covidData["state"]], covidData["cases"], covidData["deaths"]]
        sqlString = """INSERT INTO COVID_COUNTY(CVC_DATE, CVC_COUNTY, CVC_STATE, CVC_CASES, CVC_DEATHS) VALUES
        (?, ?, ?, ?, ?)"""
        dbConnection.execute(sqlString, sqlParameters)
dbConnection.commit()

apiCall = "https://api.covidtracking.com/v1/states/daily.json"
apiSource = ('https://api.covidtracking.com',)
covidFile = requests.get(apiCall)
covidJSON = json.loads(covidFile.text)

dbCursor = dbConnection.execute("SELECT MAX(CVS_DATE) FROM COVID_STATE;").fetchone()
lastDate = dbCursor[0]
dbCursor = dbConnection.execute("""SELECT CFD_API_FIELD, CFD_SQL_FIELD
FROM COVID_FIELD_DICTIONARY
WHERE CFD_SQL_TABLE = 'COVID_STATE'
AND CFD_API_CALL = ?;""", apiSource).fetchall()

covidFieldDictionary = {}
for dbRows in dbCursor:
    covidFieldDictionary[dbRows[0]] = dbRows[1]

for covidData in covidJSON:
    if lastDate is None or covidData["date"] > lastDate:
        sqlParameters = []
        sqlString = "INSERT INTO COVID_STATE("
        for key, value in covidData.items():
            if key in covidFieldDictionary.keys():
                sqlString += covidFieldDictionary[key] + ", "
                sqlParameters.append(value)
        sqlString = sqlString[:-2] + ") VALUES ("
        for x in range(len(sqlParameters)):
            if x == len(sqlParameters) - 1:
                sqlString += "?)"
            else:
                sqlString += "?, "
        dbConnection.execute(sqlString, sqlParameters)
dbConnection.commit()
dbConnection.close()

