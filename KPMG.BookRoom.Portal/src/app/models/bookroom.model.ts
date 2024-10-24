export interface BookRoomModel{
    id: string,
    name: string,
    bookedDate : Date ,
    from: string,
    to : string,
    room: roomModel
  }

  export interface roomModel{
    id: string,
    name: string,
    code: string,
    isactive: boolean
  }