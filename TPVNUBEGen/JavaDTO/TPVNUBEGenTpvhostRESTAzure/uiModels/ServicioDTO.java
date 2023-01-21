	
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
		
		
		public class ServicioDTO 	    implements IDTO
	    {
				private Integer id;
				public Integer getId () { return id; } 
				public void setId  (Integer value) { id = value;  } 
				    	 
				private Integer negocio_oid;
				public Integer  getNegocio_oid () { return negocio_oid; } 
				public void setNegocio_oid (Integer value) { negocio_oid = value;  } 
				    	 
				private String nombre;
				public String getNombre () { return nombre; } 
				public void setNombre  (String value) { nombre = value;  } 
				    	 
				private Double costo;
				public Double getCosto () { return costo; } 
				public void setCosto  (Double value) { costo = value;  } 
				    	 
				private ArrayList<LineaCompraProveedorDTO> lineaProveedor;
				public ArrayList<LineaCompraProveedorDTO> getLineaProveedor () { return lineaProveedor; } 
				public void setLineaProveedor (ArrayList<LineaCompraProveedorDTO> value) { lineaProveedor = value;  } 
				    	 
				private String codigoContrato;
				public String getCodigoContrato () { return codigoContrato; } 
				public void setCodigoContrato  (String value) { codigoContrato = value;  } 
				    	 
				private Integer categoriaServicio_oid;
				public Integer  getCategoriaServicio_oid () { return categoriaServicio_oid; } 
				public void setCategoriaServicio_oid (Integer value) { categoriaServicio_oid = value;  } 
				    	 
	   
			    public JSONObject toJSON ()
				{
					JSONObject json = new JSONObject();
					
					try
					{
				
						  json.put("Id", this.id.intValue());
				

						if (this.negocio_oid != null)
						{
							json.put("Negocio_oid", this.negocio_oid.intValue());
						}
				
						  json.put("Nombre", this.nombre);
				
					    if (this.costo != null){											
						  json.put("Costo", this.costo);
				
						}

						if (this.lineaProveedor != null)
						{
							JSONArray jsonArray = new JSONArray();
							for (int i = 0; i < this.lineaProveedor.size(); ++i)
							{
								jsonArray.put(this.lineaProveedor.get(i).toJSON());
							}
							json.put("LineaProveedor", jsonArray);
						}
					    if (this.codigoContrato != null){											
						  json.put("CodigoContrato", this.codigoContrato);
				
						}

						if (this.categoriaServicio_oid != null)
						{
							json.put("CategoriaServicio_oid", this.categoriaServicio_oid.intValue());
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
	   
	   
	   
		
	