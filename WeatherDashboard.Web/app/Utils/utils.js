var convertToCelsius = function (temp) {
    return Math.round(((temp - 32) / 1.8) * 100) / 100;
}

var convertToFahrenheit = function (temp) {
    return (temp * 1.8) + 32;
}