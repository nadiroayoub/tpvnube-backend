	
		//
		// EmpresaDTO.swift
		// 
		// Code autogenerated. Do not modify this file.
		//
		
		import Foundation
		import SwiftyJSON
	
		 class EmpresaDTO 	    {
		 
				var id: Int?;
				    	 
		 
				var nombre: String?;
				    	 
		 
				var direccion: String?;
				    	 
		 
				var duenyo_oid: Int?;
				    	 
		 
				var negocio_oid: [Int]?;
				    	 
		 
				var cif: String?;
				    	 
		 
				var email: String?;
				    	 
		 
				var fechaconstitucion: NSDate?;
				    	 
		 
				var telefono: String?;
				    	 
		 
				var provincia: String?;
				    	 
		 
				var ciudad: String?;
				    	 
		 
				var pais: String?;
				    	 
		 
				var cp: String?;
				    	 
	   	   
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
				

				
					dictionary["direccion"] = self.direccion;
				

					dictionary["duenyo_oid"] = self.duenyo_oid;
			

					dictionary["negocio_oid"] = self.negocio_oid;
			

				
					dictionary["cif"] = self.cif;
				

				
					dictionary["email"] = self.email;
				

				
					dictionary["fechaconstitucion"] = self.fechaconstitucion?.toString();
				

				
					dictionary["telefono"] = self.telefono;
				

				
					dictionary["provincia"] = self.provincia;
				

				
					dictionary["ciudad"] = self.ciudad;
				

				
					dictionary["pais"] = self.pais;
				

				
					dictionary["cp"] = self.cp;
				
						
				return dictionary;
			}
		}
		
	