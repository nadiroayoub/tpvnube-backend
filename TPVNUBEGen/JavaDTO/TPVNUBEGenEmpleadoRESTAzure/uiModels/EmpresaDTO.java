	
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
		
		
		public class EmpresaDTO 	    implements IDTO
	    {
				private Integer id;
				public Integer getId () { return id; } 
				public void setId  (Integer value) { id = value;  } 
				    	 
				private String nombre;
				public String getNombre () { return nombre; } 
				public void setNombre  (String value) { nombre = value;  } 
				    	 
				private String direccion;
				public String getDireccion () { return direccion; } 
				public void setDireccion  (String value) { direccion = value;  } 
				    	 
				private Integer duenyo_oid;
				public Integer  getDuenyo_oid () { return duenyo_oid; } 
				public void setDuenyo_oid (Integer value) { duenyo_oid = value;  } 
				    	 
				private ArrayList<Integer> negocio_oid;
				public ArrayList<Integer>  getNegocio_oid () { return negocio_oid; } 
				public void setNegocio_oid (ArrayList<Integer> value) { negocio_oid = value;  } 
				    	 
				private String cif;
				public String getCif () { return cif; } 
				public void setCif  (String value) { cif = value;  } 
				    	 
				private String email;
				public String getEmail () { return email; } 
				public void setEmail  (String value) { email = value;  } 
				    	 
				private java.util.Date fechaconstitucion;
				public java.util.Date getFechaconstitucion () { return fechaconstitucion; } 
				public void setFechaconstitucion  (java.util.Date value) { fechaconstitucion = value;  } 
				    	 
				private String telefono;
				public String getTelefono () { return telefono; } 
				public void setTelefono  (String value) { telefono = value;  } 
				    	 
				private String provincia;
				public String getProvincia () { return provincia; } 
				public void setProvincia  (String value) { provincia = value;  } 
				    	 
				private String ciudad;
				public String getCiudad () { return ciudad; } 
				public void setCiudad  (String value) { ciudad = value;  } 
				    	 
				private String pais;
				public String getPais () { return pais; } 
				public void setPais  (String value) { pais = value;  } 
				    	 
				private String cp;
				public String getCp () { return cp; } 
				public void setCp  (String value) { cp = value;  } 
				    	 
	   
			    public JSONObject toJSON ()
				{
					JSONObject json = new JSONObject();
					
					try
					{
				
						  json.put("Id", this.id.intValue());
				
				
						  json.put("Nombre", this.nombre);
				
				
						  json.put("Direccion", this.direccion);
				

						if (this.duenyo_oid != null)
						{
							json.put("Duenyo_oid", this.duenyo_oid.intValue());
						}

						if (this.negocio_oid != null)
						{
							JSONArray jsonArray = new JSONArray();
							for (int i = 0; i < this.negocio_oid.size(); ++i)
							{
								jsonArray.put(this.negocio_oid.get(i));
							}
							json.put("Negocio_oid", jsonArray);
						}
		
				
						  json.put("Cif", this.cif);
				
				
						  json.put("Email", this.email);
				
				
						  json.put("Fechaconstitucion", DateUtils.dateToFormatString(this.fechaconstitucion));
				
				
						  json.put("Telefono", this.telefono);
				
				
						  json.put("Provincia", this.provincia);
				
				
						  json.put("Ciudad", this.ciudad);
				
				
						  json.put("Pais", this.pais);
				
				
						  json.put("Cp", this.cp);
				
						
					}
					catch (JSONException e)
					{
						e.printStackTrace();
					}
				
				return json;
			}
		
			// endregion
		}
	   
	   
	   
		
	