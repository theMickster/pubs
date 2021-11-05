import { Injectable } from "@angular/core";
import { CountryRegion } from "../data-structures/models/CountryRegion";
import { StateProvince } from "../data-structures/models/StateProvince";

@Injectable({
    providedIn: 'root'
  })

export class StateProvinceService {

    private stateProvinces : StateProvince[] = [];

    constructor(){
        this.populateStateProvinces();
    }

    public getStateProvinces() : StateProvince[] 
    {
        return this.stateProvinces;
    }

    private populateStateProvinces(){
        this.stateProvinces =  [
            new StateProvince(1, 'US', 'AL ', 'Alabama' ),
            new StateProvince(2, 'US', 'AK ', 'Alaska' ),
            new StateProvince(3, 'US', 'AZ ', 'Arizona' ),
            new StateProvince(4, 'US', 'AR ', 'Arkansas' ),
            new StateProvince(5, 'US', 'CA ', 'California' ),
            new StateProvince(6, 'US', 'CO ', 'Colorado' ),
            new StateProvince(7, 'US', 'CT ', 'Connecticut' ),
            new StateProvince(8, 'US', 'DE ', 'Delaware' ),
            new StateProvince(9, 'US', 'DC ', 'District of Columbia' ),
            new StateProvince(10, 'US', 'FL ', 'Florida' ),
            new StateProvince(11, 'US', 'GA ', 'Georgia' ),
            new StateProvince(12, 'US', 'GU ', 'Guam' ),
            new StateProvince(13, 'US', 'HI ', 'Hawaii' ),
            new StateProvince(14, 'US', 'ID ', 'Idaho' ),
            new StateProvince(15, 'US', 'IL ', 'Illinois' ),
            new StateProvince(16, 'US', 'IN ', 'Indiana' ),
            new StateProvince(17, 'US', 'IA ', 'Iowa' ),
            new StateProvince(18, 'US', 'KS ', 'Kansas' ),
            new StateProvince(19, 'US', 'KY ', 'Kentucky' ),
            new StateProvince(20, 'US', 'LA ', 'Louisiana' ),
            new StateProvince(21, 'US', 'ME ', 'Maine' ),
            new StateProvince(22, 'US', 'MD ', 'Maryland' ),
            new StateProvince(23, 'US', 'MA ', 'Massachusetts' ),
            new StateProvince(24, 'US', 'MI ', 'Michigan' ),
            new StateProvince(25, 'US', 'MN ', 'Minnesota' ),
            new StateProvince(26, 'US', 'MS ', 'Mississippi' ),
            new StateProvince(27, 'US', 'MO ', 'Missouri' ),
            new StateProvince(28, 'US', 'MT ', 'Montana' ),
            new StateProvince(29, 'US', 'NE ', 'Nebraska' ),
            new StateProvince(30, 'US', 'NV ', 'Nevada' ),
            new StateProvince(31, 'US', 'NH ', 'New Hampshire' ),
            new StateProvince(32, 'US', 'NJ ', 'New Jersey' ),
            new StateProvince(33, 'US', 'NM ', 'New Mexico' ),
            new StateProvince(34, 'US', 'NY ', 'New York' ),
            new StateProvince(35, 'US', 'NC ', 'North Carolina' ),
            new StateProvince(36, 'US', 'ND ', 'North Dakota' ),
            new StateProvince(37, 'US', 'OH ', 'Ohio' ),
            new StateProvince(38, 'US', 'OK ', 'Oklahoma' ),
            new StateProvince(39, 'US', 'OR ', 'Oregon' ),
            new StateProvince(40, 'US', 'PA ', 'Pennsylvania' ),
            new StateProvince(41, 'US', 'PR ', 'Puerto Rico' ),
            new StateProvince(42, 'US', 'RI ', 'Rhode Island' ),
            new StateProvince(43, 'US', 'SC ', 'South Carolina' ),
            new StateProvince(44, 'US', 'SD ', 'South Dakota' ),
            new StateProvince(45, 'US', 'TN ', 'Tennessee' ),
            new StateProvince(46, 'US', 'TX ', 'Texas' ),
            new StateProvince(47, 'US', 'UT ', 'Utah' ),
            new StateProvince(48, 'US', 'VT ', 'Vermont' ),
            new StateProvince(49, 'US', 'VA ', 'Virginia' ),
            new StateProvince(50, 'US', 'WA ', 'Washington' ),
            new StateProvince(51, 'US', 'WV ', 'West Virginia' ),
            new StateProvince(52, 'US', 'WI ', 'Wisconsin' ),
            new StateProvince(53, 'US', 'WY ', 'Wyoming' ),
            new StateProvince(101, 'CA', 'AB ', 'Alberta' ),
            new StateProvince(102, 'CA', 'BC ', 'British Columbia' ),
            new StateProvince(103, 'CA', 'NB ', 'Brunswick' ),
            new StateProvince(104, 'CA', 'LB ', 'Labrador' ),
            new StateProvince(105, 'CA', 'MB ', 'Manitoba' ),
            new StateProvince(106, 'CA', 'NF ', 'Newfoundland' ),
            new StateProvince(107, 'CA', 'NT ', 'Northwest Territories' ),
            new StateProvince(108, 'CA', 'NS ', 'Nova Scotia' ),
            new StateProvince(109, 'CA', 'ON ', 'Ontario' ),
            new StateProvince(110, 'CA', 'PE ', 'Prince Edward Island' ),
            new StateProvince(111, 'CA', 'QC ', 'Quebec' ),
            new StateProvince(112, 'CA', 'SK ', 'Saskatchewan' ),
            new StateProvince(113, 'CA', 'YT ', 'Yukon Territory' )
        ]
    }
}