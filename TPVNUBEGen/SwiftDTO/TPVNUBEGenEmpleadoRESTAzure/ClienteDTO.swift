	
		//
		// ClienteDTO.swift
		// 
		// Code autogenerated. Do not modify this file.
		//
		
		import Foundation
		import SwiftyJSON
	
		 class ClienteDTO 	    {
		 
				var dni: String?;
				    	 
		 
				var nombre: String?;
				    	 
		 
				var apellidos: String?;
				    	 
		 
				var factura_oid: [Int]?;
				    	 
		 
				var cobro_oid: [Int]?;
				    	 
		 
				var id: Int?;
				    	 
		 
				var negocio_oid: Int?;
				    	 
		 
				var email: String?;
				    	 
	   	   
			// MARK: - Constructor
			
			
		
			init ()
			{
				// Empty constructor
			}
			 func toDictionary() -> [String : AnyObject]
		
		   
			{
				var dictionary: [String : AnyObject] = [:];
				
			


				
					dictionary["dni"] = self.dni;
				

				
					dictionary["nombre"] = self.nombre;
				

				
					dictionary["apellidos"] = self.apellidos;
				

					dictionary["factura_oid"] = self.factura_oid;
			

					dictionary["cobro_oid"] = self.cobro_oid;
			

				
					dictionary["id"] = self.id;
				

					dictionary["negocio_oid"] = self.negocio_oid;
			

				
					dictionary["email"] = self.email;
				
						
				return dictionary;
			}
		}
		
	