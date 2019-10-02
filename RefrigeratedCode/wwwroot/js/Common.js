var formatDate = function(date) {
    var dateString = new Date(date);
    var meridiem = 'AM';
    if (dateString.getHours() > 12) {
        meridiem = 'PM';
    }
    return (dateString.getMonth() + 1) +
        "/" +
        dateString.getDate() +
        "/" +
        dateString.getFullYear() +
        " " +
        (dateString.getHours() % 12) +
        ":" +
        dateString.getMinutes() +
        " " +
        meridiem;
}