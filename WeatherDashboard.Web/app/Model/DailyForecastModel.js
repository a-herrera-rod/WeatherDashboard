function DailyForecast(data) {
    var Me = this;
    var status;
    var day;
    var temperature_max;
    var temperature_min;
    var icon;

    this.getStatus = function () {
        return status;
    }

    this.setStatus = function (value) {
        if (value != null) {
            status = value;
        }
    }

    this.getDay = function () {
        return day;
    }

    this.setDay = function (value) {
        if (value != null) {
            day = value;
        }
    }

    this.getTemperatureMax = function (unit) {
        if (unit == "F") {
            return temperature_max;
        }
        else {
            return convertToCelsius(temperature_max);
        }
    }

    this.getTemperatureMin = function (unit) {
        if (unit == "F") {
            return temperature_min;
        }
        else {
            return convertToCelsius(temperature_min);
        }
    }

    this.setTemperatureMax = function (value) {
        if (value != null) {
            temperature_max = value;
        }
    }

    this.setTemperatureMin = function (value) {
        if (value != null) {
            temperature_min = value;
        }
    }

    this.getIcon = function () {
        return icon;
    }

    this.setIcon = function (value) {
        if (value != null) {
            icon = value;
        }
    }

    if (data != null) {
        Me.setStatus(data.status);
        Me.setDay(data.day)
        Me.setTemperatureMax(data.temperature_maximum);
        Me.setTemperatureMin(data.temperature_minimum);
        Me.setIcon(data.icon);
    }
}