//
// NegocioDTOA.swift
// 
// Code autogenerated. Do not modify this file.
//

import Foundation
import SwiftyJSON
		
class NegocioDTOA : DTOA
{
	// MARK: - Properties

	var id: Int?;
	
	var nombre: String?;
	var direccion: String?;
	var ciudad: String?;
	var cp: String?;
	var provincia: String?;
	var pais: String?;
	
	/* Rol: Negocio o--> Caja */
	var cajaOfNegocio: [CajaDTOA]?;

	
	
	
	
	// MARK: - Constructor
	
	init ()
	{
		// Empty constructor
	}
	
	
	
	// MARK: - JSON <-> DTOA
	
	required init (fromJSONObject json: JSON)
	{
		self.id = json["Id"].object as? Int
		
	
		self.nombre = json["Nombre"].object as? String;
		self.direccion = json["Direccion"].object as? String;
		self.ciudad = json["Ciudad"].object as? String;
		self.cp = json["Cp"].object as? String;
		self.provincia = json["Provincia"].object as? String;
		self.pais = json["Pais"].object as? String;
		
		if (json["CajaOfNegocio"] != JSON.null)
		{
			self.cajaOfNegocio = [];
			for subJson in json["CajaOfNegocio"].arrayValue
			{
				self.cajaOfNegocio!.append(CajaDTOA(fromJSONObject: subJson));
			}
		}

		
	}
	
	func toDictionary() -> [String : AnyObject]
	{
		var dictionary: [String : AnyObject] = [:];
		
		dictionary["Id"] = self.id;
		
	

	
		dictionary["Nombre"] = self.nombre;
	
	

	
		dictionary["Direccion"] = self.direccion;
	
	

	
		dictionary["Ciudad"] = self.ciudad;
	
	

	
		dictionary["Cp"] = self.cp;
	
	

	
		dictionary["Provincia"] = self.provincia;
	
	

	
		dictionary["Pais"] = self.pais;
	
	
		
		dictionary["CajaOfNegocio"] = NSNull();
		if (self.cajaOfNegocio != nil)
		{
			var arrayOfDictionary: [[String : AnyObject]] = [];
			for item in self.cajaOfNegocio!
			{
				arrayOfDictionary.append(item.toDictionary());
			}
			
			dictionary["CajaOfNegocio"] = arrayOfDictionary;
		}

		
		
		return dictionary;
	}
}

	