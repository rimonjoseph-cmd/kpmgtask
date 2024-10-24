import { BuildingModel } from "./building.model";

// room.model.ts
export interface RoomModel {
    id: string;
    name: string;
    code: string;
    isactive: boolean;
    building: BuildingModel;
  }

  interface roomModel{
    id: string,
    name: string,
    code: string,
    isactive: boolean
  }