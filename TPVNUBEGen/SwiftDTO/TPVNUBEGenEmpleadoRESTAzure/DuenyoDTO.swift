	
		//
		// DuenyoDTO.swift
		// 
		// Code autogenerated. Do not modify this file.
		//
		
		import Foundation
		import SwiftyJSON
	
		 class DuenyoDTO 	    {
		 
				var dni: String?;
				    	 
		 
				var empresa_oid: [Int]?;
				    	 
		 
				var nombre: String?;
				    	 
		 
				var apellidos: String?;
				    	 
		 
				var telefono: String?;
				    	 
		 
				var pass: String?;
				    	 
		 
				var id: Int?;
				    	 
		 
				var email: String?;
				    	 
		 
				var caja_oid: [Int]?;
				    	 
		 
				var foto: String?;
				    	 
	   	   
			// MARK: - Constructor
			
			
		
			init ()
			{
				// Empty constructor
			}
			 func toDictionary() -> [String : AnyObject]
		
		   
			{
				var dictionary: [String : AnyObject] = [:];
				
			


				
					dictionary["dni"] = self.dni;
				

					dictionary["empresa_oid"] = self.empresa_oid;
			

				
					dictionary["nombre"] = self.nombre;
				

				
					dictionary["apellidos"] = self.apellidos;
				

				
					dictionary["telefono"] = self.telefono;
				

				
					dictionary["pass"] = self.pass;
				

				
					dictionary["id"] = self.id;
				

				
					dictionary["email"] = self.email;
				

					dictionary["caja_oid"] = self.caja_oid;
			

				
					dictionary["foto"] = self.foto;
				
						
				return dictionary;
			}
		}
		
	