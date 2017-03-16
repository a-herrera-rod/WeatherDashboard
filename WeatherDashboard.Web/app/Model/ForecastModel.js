function Forecast(data) {
    var Me = this;
    var status;
    var temperature;
    var icon;
    var dailyForecast;
    
    this.getStatus = function () {
        return status;
    }

    this.setStatus = function (value) {
        if (value != null) {
            status = value;
        }
    }

    this.getTemperature = function (unit) {
        if (unit == "F") {
            return temperature;
        }
        else {
            return convertToCelsius(temperature);
        }
    }

    this.setTemperature = function (value) {
        if (value != null) {
            temperature = value;
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

    this.getDailyForecast = function () {
        return dailyForecast;
    }

    this.setDailyForecast = function (value) {
        if (value != null) {
            if (dailyForecast == null) {
                dailyForecast = [];
            }
            for (var i = 0; i < value.length; i++) {
                dailyForecast.push(new DailyForecast(value[i]));
            }            
        }
    }

    if (data != null) {
        Me.setStatus(data.status);
        Me.setTemperature(data.temperature);
        Me.setIcon(data.icon);
        Me.setDailyForecast(data.dailyForecast);
    }
}