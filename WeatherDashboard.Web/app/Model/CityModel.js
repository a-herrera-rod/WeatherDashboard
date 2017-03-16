function City(data) {
    var Me = this;
    var id;
    var name;
    var country;
    var lat;
    var long;

    this.getId = function () {
        return id;
    }

    this.setId = function (value) {
        if (value != null) {
            id = value;
        }
    }

    this.getName = function () {
        return name;
    }

    this.setName = function (value) {
        if (value != null) {
            name = value;
        }
    }

    this.getCountry = function () {
        return country;
    }

    this.setCountry = function (value) {
        if (value != null) {
            country = value;
        }
    }

    this.getLatitude = function () {
        return lat;
    }

    this.setLatitude = function (value) {
        if (value != null) {
            lat = value;
        }
    }

    this.getLongitude = function () {
        return long;
    }

    this.setLongitude = function (value) {
        if (value != null) {
            long = value;
        }
    }

    if (data != null) {
        Me.setId(data.id);
        Me.setName(data.name);
        Me.setCountry(data.country);
        Me.setLatitude(data.latitude);
        Me.setLongitude(data.longitude);        
    }
}