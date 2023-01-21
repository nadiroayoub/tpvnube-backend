	
		package TPVNUBEGenEmpleadoRESTAzure.uiModels.DTO;
		
		import java.util.ArrayList;
		
		import org.json.JSONArray;
		import org.json.JSONException;
		import org.json.JSONObject;
		import  TPVNUBEGenEmpleadoRESTAzure.uiModels.DTO.utils.*;
		import  TPVNUBEGenEmpleadoRESTAzure.uiModels.DTO.enumerations.*;
		
		
		/**
		 * Code autogenerated. Do not modify this file.
		 */
		
		
		public class EmpleadoDTO 	    implements IDTO
	    {
				private Integer negocio_oid;
				public Integer  getNegocio_oid () { return negocio_oid; } 
				public void setNegocio_oid (Integer value) { negocio_oid = value;  } 
				    	 
				private String nombre;
				public String getNombre () { return nombre; } 
				public void setNombre  (String value) { nombre = value;  } 
				    	 
				private String apellidos;
				public String getApellidos () { return apellidos; } 
				public void setApellidos  (String value) { apellidos = value;  } 
				    	 
				private String pass;
				public String getPass () { return pass; } 
				public void setPass  (String value) { pass = value;  } 
				    	 
				private String foto;
				public String getFoto () { return foto; } 
				public void setFoto  (String value) { foto = value;  } 
				    	 
				private ArrayList<Integer> comanda_oid;
				public ArrayList<Integer>  getComanda_oid () { return comanda_oid; } 
				public void setComanda_oid (ArrayList<Integer> value) { comanda_oid = value;  } 
				    	 
				private Integer id;
				public Integer getId () { return id; } 
				public void setId  (Integer value) { id = value;  } 
				    	 
				private String dni;
				public String getDni () { return dni; } 
				public void setDni  (String value) { dni = value;  } 
				    	 
				private String email;
				public String getEmail () { return email; } 
				public void setEmail  (String value) { email = value;  } 
				    	 
				private String telefono;
				public String getTelefono () { return telefono; } 
				public void setTelefono  (String value) { telefono = value;  } 
				    	 
				private ArrayList<Integer> cobro_oid;
				public ArrayList<Integer>  getCobro_oid () { return cobro_oid; } 
				public void setCobro_oid (ArrayList<Integer> value) { cobro_oid = value;  } 
				    	 
	   
			    public JSONObject toJSON ()
				{
					JSONObject json = new JSONObject();
					
					try
					{

						if (this.negocio_oid != null)
						{
							json.put("Negocio_oid", this.negocio_oid.intValue());
						}
				
						  json.put("Nombre", this.nombre);
				
				
						  json.put("Apellidos", this.apellidos);
				
				
						  json.put("Pass", this.pass);
				
				
						  json.put("Foto", this.foto);
				

						if (this.comanda_oid != null)
						{
							JSONArray jsonArray = new JSONArray();
							for (int i = 0; i < this.comanda_oid.size(); ++i)
							{
								jsonArray.put(this.comanda_oid.get(i));
							}
							json.put("Comanda_oid", jsonArray);
						}
		
				
						  json.put("Id", this.id.intValue());
				
				
						  json.put("Dni", this.dni);
				
				
						  json.put("Email", this.email);
				
				
						  json.put("Telefono", this.telefono);
				

						if (this.cobro_oid != null)
						{
							JSONArray jsonArray = new JSONArray();
							for (int i = 0; i < this.cobro_oid.size(); ++i)
							{
								jsonArray.put(this.cobro_oid.get(i));
							}
							json.put("Cobro_oid", jsonArray);
						}
		
						
					}
					catch (JSONException e)
					{
						e.printStackTrace();
					}
				
				return json;
			}
		
			// endregion
		}
	   
	   
	   
		
	