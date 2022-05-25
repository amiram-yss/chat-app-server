function isSameDay(date1, date2) {
    if (
        date1.getFullYear() === date2.getFullYear() &&
        date1.getMonth() === date2.getMonth() &&
        date1.getDate() === date2.getDate()
    )
        return true
    return false
}

function getDateString(date) {
    return date.getDay().toString() + '/' + date.getMonth().toString()
}

function getTimeString(date) {
    //console.log(date.toString())
    let hour = date.getHours().toString()
    let minute = date.getMinutes().toString().padStart(2, '0')
    return hour + ':' + minute
}

function timeStringForComponents(date) {
    let str = ''
    let now = new Date()
    if (!isSameDay(now, date))
        str.concat(getDateString(date))
    str += getTimeString(date)
    return str
}

export default timeStringForComponents