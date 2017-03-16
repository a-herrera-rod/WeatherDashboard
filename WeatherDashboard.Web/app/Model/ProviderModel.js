function Provider(data) {
    var Me = this;
    var id;
    var name;

    this.setId = function (value) {
        if (value != null) {
            id = value;
        }
    }

    this.getId = function () {
        return id;
    }

    this.setName = function (value) {
        name = value;
    }

    this.getName = function () {
        return name;
    }

    if (data != null) {
        Me.setId(data.id);
        Me.setName(data.name);
    }
}