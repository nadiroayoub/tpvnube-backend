	
		package TPVNUBEGenTpvhostRESTAzure.uiModels.DTO;
		
		import java.util.ArrayList;
		
		import org.json.JSONArray;
		import org.json.JSONException;
		import org.json.JSONObject;
		import  TPVNUBEGenTpvhostRESTAzure.uiModels.DTO.utils.*;
		import  TPVNUBEGenTpvhostRESTAzure.uiModels.DTO.enumerations.*;
		
		
		/**
		 * Code autogenerated. Do not modify this file.
		 */
		
		
		public class PlatoDTO 	    implements IDTO
	    {
				private Integer id;
				public Integer getId () { return id; } 
				public void setId  (Integer value) { id = value;  } 
				    	 
				private String nombre;
				public String getNombre () { return nombre; } 
				public void setNombre  (String value) { nombre = value;  } 
				    	 
				private Double stock;
				public Double getStock () { return stock; } 
				public void setStock  (Double value) { stock = value;  } 
				    	 
				private Double precio;
				public Double getPrecio () { return precio; } 
				public void setPrecio  (Double value) { precio = value;  } 
				    	 
				private ArrayList<LineaPlatoDTO> lineaPlato;
				public ArrayList<LineaPlatoDTO> getLineaPlato () { return lineaPlato; } 
				public void setLineaPlato (ArrayList<LineaPlatoDTO> value) { lineaPlato = value;  } 
				    	 
				private ArrayList<LineaMenuDTO> lineaMenu;
				public ArrayList<LineaMenuDTO> getLineaMenu () { return lineaMenu; } 
				public void setLineaMenu (ArrayList<LineaMenuDTO> value) { lineaMenu = value;  } 
				    	 
				private String foto;
				public String getFoto () { return foto; } 
				public void setFoto  (String value) { foto = value;  } 
				    	 
				private Integer tipoPlato_oid;
				public Integer  getTipoPlato_oid () { return tipoPlato_oid; } 
				public void setTipoPlato_oid (Integer value) { tipoPlato_oid = value;  } 
				    	 
				private ArrayList<Integer> lineaComanda_oid;
				public ArrayList<Integer>  getLineaComanda_oid () { return lineaComanda_oid; } 
				public void setLineaComanda_oid (ArrayList<Integer> value) { lineaComanda_oid = value;  } 
				    	 
				private Integer negocio_oid;
				public Integer  getNegocio_oid () { return negocio_oid; } 
				public void setNegocio_oid (Integer value) { negocio_oid = value;  } 
				    	 
	   
			    public JSONObject toJSON ()
				{
					JSONObject json = new JSONObject();
					
					try
					{
				
						  json.put("Id", this.id.intValue());
				
				
						  json.put("Nombre", this.nombre);
				
					    if (this.stock != null){											
						  json.put("Stock", this.stock);
				
						}
				
						  json.put("Precio", this.precio);
				

						if (this.lineaPlato != null)
						{
							JSONArray jsonArray = new JSONArray();
							for (int i = 0; i < this.lineaPlato.size(); ++i)
							{
								jsonArray.put(this.lineaPlato.get(i).toJSON());
							}
							json.put("LineaPlato", jsonArray);
						}

						if (this.lineaMenu != null)
						{
							JSONArray jsonArray = new JSONArray();
							for (int i = 0; i < this.lineaMenu.size(); ++i)
							{
								jsonArray.put(this.lineaMenu.get(i).toJSON());
							}
							json.put("LineaMenu", jsonArray);
						}
				
						  json.put("Foto", this.foto);
				

						if (this.tipoPlato_oid != null)
						{
							json.put("TipoPlato_oid", this.tipoPlato_oid.intValue());
						}

						if (this.lineaComanda_oid != null)
						{
							JSONArray jsonArray = new JSONArray();
							for (int i = 0; i < this.lineaComanda_oid.size(); ++i)
							{
								jsonArray.put(this.lineaComanda_oid.get(i));
							}
							json.put("LineaComanda_oid", jsonArray);
						}
		

						if (this.negocio_oid != null)
						{
							json.put("Negocio_oid", this.negocio_oid.intValue());
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
	   
	   
	   
		
	