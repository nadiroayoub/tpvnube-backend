//
// EmpresaDTOA.swift
// 
// Code autogenerated. Do not modify this file.
//

import Foundation
import SwiftyJSON
		
class EmpresaDTOA : DTOA
{
	// MARK: - Properties

	var id: Int?;
	
	var nombre: String?;
	var direccion: String?;
	var cif: String?;
	var email: String?;
	var fechaconstitucion: NSDate?;
	var telefono: String?;
	var ciudad: String?;
	var pais: String?;
	var cp: String?;
	var provincia: String?;
	
	
	
	
	
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
		self.cif = json["Cif"].object as? String;
		self.email = json["Email"].object as? String;
	
		self.fechaconstitucion = NSDate.initFromString(json["Fechaconstitucion"].object as? String);
		self.telefono = json["Telefono"].object as? String;
		self.ciudad = json["Ciudad"].object as? String;
		self.pais = json["Pais"].object as? String;
		self.cp = json["Cp"].object as? String;
		self.provincia = json["Provincia"].object as? String;
		
		
	}
	
	func toDictionary() -> [String : AnyObject]
	{
		var dictionary: [String : AnyObject] = [:];
		
		dictionary["Id"] = self.id;
		
	

	
		dictionary["Nombre"] = self.nombre;
	
	

	
		dictionary["Direccion"] = self.direccion;
	
	

	
		dictionary["Cif"] = self.cif;
	
	

	
		dictionary["Email"] = self.email;
	
	

	
		dictionary["Fechaconstitucion"] = self.fechaconstitucion?.toString();
	
	

	
		dictionary["Telefono"] = self.telefono;
	
	

	
		dictionary["Ciudad"] = self.ciudad;
	
	

	
		dictionary["Pais"] = self.pais;
	
	

	
		dictionary["Cp"] = self.cp;
	
	

	
		dictionary["Provincia"] = self.provincia;
	
	
		
		
		
		return dictionary;
	}
}

	