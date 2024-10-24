let mainUrl = "https://localhost:7280/api/";
export const  links = {
    "getallbuilding" : mainUrl + "Building",
    "createbuilding" : mainUrl + "Building",
    "contact": {
        "registernew" : mainUrl + "contact",
        "login" : mainUrl + "contact"+ "/login",
        "register" : mainUrl + "contact"+ "/register",
    },
    "bookrooms": {
        "mybookroooms" : mainUrl + "book/own",
        "createbook" : mainUrl + "book",
        "allbooks" : mainUrl + "book"
    },
    "rooms": {
        "availableRooms" : mainUrl + "room/getavailable",
        "allRooms" : mainUrl + "room",
        "createRoom" : mainUrl + "room",
        "getRoom" : mainUrl + "room"
    },
    "timeslots": {
        "getall" : mainUrl + "TimeSlot"
    }
};