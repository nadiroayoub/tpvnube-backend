	
		//
		// ProveedorDTO.swift
		// 
		// Code autogenerated. Do not modify this file.
		//
		
		import Foundation
		import SwiftyJSON
	
		 class ProveedorDTO 	    {
		 
				var id: Int?;
				    	 
		 
				var nombre: String?;
				    	 
		 
				var compraProveedor_oid: [Int]?;
				    	 
		 
				var email: String?;
				    	 
		 
				var telefono: String?;
				    	 
	   	   
			// MARK: - Constructor
			
			
		
			init ()
			{
				// Empty constructor
			}
			 func toDictionary() -> [String : AnyObject]
		
		   
			{
				var dictionary: [String : AnyObject] = [:];
				
			


				
					dictionary["id"] = self.id;
				

				
					dictionary["nombre"] = self.nombre;
				

					dictionary["compraProveedor_oid"] = self.compraProveedor_oid;
			

				
					dictionary["email"] = self.email;
				

				
					dictionary["telefono"] = self.telefono;
				
						
				return dictionary;
			}
		}
		
	