	
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
		
		
		public class ProductoDTO 	    implements IDTO
	    {
				private Integer id;
				public Integer getId () { return id; } 
				public void setId  (Integer value) { id = value;  } 
				    	 
				private Double stock;
				public Double getStock () { return stock; } 
				public void setStock  (Double value) { stock = value;  } 
				    	 
				private Integer unidadMedida_oid;
				public Integer  getUnidadMedida_oid () { return unidadMedida_oid; } 
				public void setUnidadMedida_oid (Integer value) { unidadMedida_oid = value;  } 
				    	 
				private ArrayList<LineaCompraProveedorDTO> lineaCompraProveedor;
				public ArrayList<LineaCompraProveedorDTO> getLineaCompraProveedor () { return lineaCompraProveedor; } 
				public void setLineaCompraProveedor (ArrayList<LineaCompraProveedorDTO> value) { lineaCompraProveedor = value;  } 
				    	 
				private ArrayList<Integer> lineaPlato_oid;
				public ArrayList<Integer>  getLineaPlato_oid () { return lineaPlato_oid; } 
				public void setLineaPlato_oid (ArrayList<Integer> value) { lineaPlato_oid = value;  } 
				    	 
				private Integer negocio_oid;
				public Integer  getNegocio_oid () { return negocio_oid; } 
				public void setNegocio_oid (Integer value) { negocio_oid = value;  } 
				    	 
				private String descripcion;
				public String getDescripcion () { return descripcion; } 
				public void setDescripcion  (String value) { descripcion = value;  } 
				    	 
	   
			    public JSONObject toJSON ()
				{
					JSONObject json = new JSONObject();
					
					try
					{
				
						  json.put("Id", this.id.intValue());
				
					    if (this.stock != null){											
						  json.put("Stock", this.stock);
				
						}

						if (this.unidadMedida_oid != null)
						{
							json.put("UnidadMedida_oid", this.unidadMedida_oid.intValue());
						}

						if (this.lineaCompraProveedor != null)
						{
							JSONArray jsonArray = new JSONArray();
							for (int i = 0; i < this.lineaCompraProveedor.size(); ++i)
							{
								jsonArray.put(this.lineaCompraProveedor.get(i).toJSON());
							}
							json.put("LineaCompraProveedor", jsonArray);
						}

						if (this.lineaPlato_oid != null)
						{
							JSONArray jsonArray = new JSONArray();
							for (int i = 0; i < this.lineaPlato_oid.size(); ++i)
							{
								jsonArray.put(this.lineaPlato_oid.get(i));
							}
							json.put("LineaPlato_oid", jsonArray);
						}
		

						if (this.negocio_oid != null)
						{
							json.put("Negocio_oid", this.negocio_oid.intValue());
						}
				
						  json.put("Descripcion", this.descripcion);
				
						
					}
					catch (JSONException e)
					{
						e.printStackTrace();
					}
				
				return json;
			}
		
			// endregion
		}
	   
	   
	   
		
	